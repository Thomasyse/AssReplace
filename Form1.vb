Imports System
Imports System.IO
Imports System.Collections
Public Class Form1
    Const bz1 As String = ",0,0,0,", bz2 As String = vbCrLf, bz3 As String = "{", bz4 As String = "}", MeHeightdef As Integer = 280
    Dim detailapp As Boolean = False, waring As String, war As Boolean

    Public Shared ReadOnly Property Bz11 As String
        Get
            Return bz1
        End Get
    End Property

    Public Shared ReadOnly Property Bz21 As String
        Get
            Return bz2
        End Get
    End Property

    Public Shared ReadOnly Property Bz31 As String
        Get
            Return bz3
        End Get
    End Property

    Public Shared ReadOnly Property Bz41 As String
        Get
            Return bz4
        End Get
    End Property

    Public Shared ReadOnly Property MeHeightdef1 As Integer
        Get
            Return MeHeightdef
        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        waring = ""
        If GBin.Text <> "" And BIG5in.Text <> "" And Out.Text <> "" Then
            If GBin.Text.IndexOf("*") > 0 And BIG5in.Text.IndexOf("*") > 0 And Out.Text.IndexOf("*") > 0 And GBin.Text.LastIndexOf("\") > 1 And BIG5in.Text.LastIndexOf("\") > 1 And Out.Text.LastIndexOf("\") > 1 Then
                Dim gbs, big5s, outs As Integer
                Dim gbpath, big5path, outpath, gbfile, big5file, outputfile As String
                gbs = GBin.Text.LastIndexOf("\")
                big5s = BIG5in.Text.LastIndexOf("\")
                outs = Out.Text.LastIndexOf("\")
                gbpath = Mid(GBin.Text, 1, gbs)
                big5path = Mid(BIG5in.Text, 1, big5s)
                outpath = Mid(Out.Text, 1, outs)
                If Not Directory.Exists(gbpath) Then
                    MessageBox.Show("GB输入文件路径不存在！")
                    Exit Sub
                End If
                If Not Directory.Exists(big5path) Then
                    MessageBox.Show("BIG5输入文件路径不存在！")
                    Exit Sub
                End If
                If Not Directory.Exists(outpath) Then
                    Dim flag As DialogResult = MessageBox.Show(Me, "输出文件路径不存在，出否要创建？", "", MessageBoxButtons.YesNo)
                    If flag = DialogResult.No Then Exit Sub
                    If flag = DialogResult.Yes Then
                        Directory.CreateDirectory(outpath)
                    End If
                End If
                Try
                    gbfile = GBin.Text
                    big5file = BIG5in.Text
                    outputfile = Out.Text
                Catch ex As Exception
                    MessageBox.Show("输入的文件名不正确！")
                    Exit Sub
                End Try
                Dim gbfilesorigin, big5filesorigin As List(Of String)
                Dim gbfiles As List(Of String) = New List(Of String), big5files As List(Of String) = New List(Of String)
                gbfilesorigin = Directory.GetFiles(gbpath).ToList
                big5filesorigin = Directory.GetFiles(big5path).ToList
                gbs = gbfile.IndexOf("*")
                big5s = big5file.IndexOf("*")
                outs = outputfile.IndexOf("*")
                Dim gbkey, big5key As System.Text.RegularExpressions.Regex
                Dim filename As String
                gbkey = New Text.RegularExpressions.Regex(returnreg(gbfile))
                For Each filename In gbfilesorigin
                    If gbkey.IsMatch(filename) Then
                        gbfiles.Add(filename)
                    End If
                Next
                big5key = New Text.RegularExpressions.Regex(returnreg(big5file))
                For Each filename In big5filesorigin
                    If big5key.IsMatch(filename) Then
                        big5files.Add(filename)
                    End If
                Next
                Dim gbfilekey As List(Of String) = New List(Of String)
                For Each filename In gbfiles
                    gbfilekey.Add(filename.Replace(Mid(gbfile, 1, gbs), "").Replace(Mid(gbfile, gbs + 2), ""))
                Next
                Dim gbname, big5name, outname As String， ok As Integer
                For Each filename In gbfilekey
                    big5name = Mid(big5file, 1, big5s) + filename + Mid(big5file, big5s + 2)
                    If big5files.Exists(Function(x) x = big5name) Then
                        gbname = Mid(gbfile, 1, gbs) + filename + Mid(gbfile, gbs + 2)
                        outname = Mid(outputfile, 1, outs) + filename + Mid(outputfile, outs + 2)
                        ok = Replace(gbname, big5name, outname)
                        If ok = -1 Then Exit Sub
                    End If
                Next
            Else
                Replace(GBin.Text, BIG5in.Text, Out.Text)
            End If
            If waring = "" Then
                MessageBox.Show("懒癌发作完毕！")
                DetailText.Text = ""
                Detail.Visible = False
                Dim MeSize As Size
                MeSize.Width = Me.Width
                MeSize.Height = MeHeightdef
                Me.Size = MeSize
            Else
                MessageBox.Show("虽然转换成功但是存在可能的错误，具体请点击【显示详情】按钮查看详情！")
                DetailText.Text = waring
                Detail.Visible = True
                ChangeSize()
            End If
        Else
            MessageBox.Show("请输入文件路径！")
        End If
    End Sub
    Function returnreg(search As String) As String
        Dim searchregs As String = search.Replace("\", "\\")
        searchregs = searchregs.Replace("[", "\[")
        searchregs = searchregs.Replace("]", "\]")
        searchregs = searchregs.Replace("(", "\(")
        searchregs = searchregs.Replace(")", "\)")
        searchregs = searchregs.Replace("{", "\{")
        searchregs = searchregs.Replace("}", "\}")
        searchregs = searchregs.Replace("+", "\+")
        searchregs = searchregs.Replace(".", "\.")
        searchregs = searchregs.Replace("^", "\^")
        searchregs = searchregs.Replace("$", "\$")
        searchregs = searchregs.Replace("*", "(.+?)")
        Return searchregs
    End Function
    Function Replace(GBFile As String, BIG5File As String, OutputFile As String) As Integer
        war = False
        Dim gb, big5, sc As String
        gb = ""
        big5 = ""
        sc = ""
        Dim gbinput As IO.StreamReader
        Dim big5input As IO.StreamReader
        Try
            Dim outs As Integer = OutputFile.LastIndexOf("\")
            Dim outpath As String = Mid(OutputFile, 1, outs)
            If Not Directory.Exists(outpath) Then
                Directory.CreateDirectory(outpath)
            End If
            gbinput = New IO.StreamReader(GBFile, System.Text.Encoding.GetEncoding("unicode"))
            big5input = New IO.StreamReader(BIG5File, System.Text.Encoding.GetEncoding("unicode"))
            FileOpen(3, OutputFile, OpenMode.Output)
        Catch ex As Exception
            MessageBox.Show("指定文件无法访问，请检查文件路径及可访问性！")
            Return -1
        End Try
        Do While Not gbinput.EndOfStream
            gb = gb + gbinput.ReadLine + vbCrLf
        Loop
        Do While Not big5input.EndOfStream
            big5 = big5 + big5input.ReadLine + vbCrLf
        Loop
        Dim gbhead, big5head, gbcount, big5count, count As Int64
        gbhead = InStr(gb, "[Events]")
        big5head = InStr(big5, "[Events]")
        gbcount = 0
        big5count = 0
        For i = gbhead To Len(gb)
            If Mid(gb, i, Len(bz1)) = bz1 Then
                gbcount = gbcount + 1
            End If
        Next
        For i = big5head To Len(big5)
            If Mid(big5, i, Len(bz1)) = bz1 Then
                big5count = big5count + 1
            End If
        Next
        count = Math.Min(gbcount, big5count)
        If gbcount <> big5count Then
            waring = waring + "GB文件: " + GBFile + vbCrLf + "BIG5文件: " + BIG5File + vbCrLf + vbCrLf + "****GB文件(" + gbcount.ToString + ")和BIG5文件(" + big5count.ToString + ")行数不相等!****" + vbCrLf
            war = True
        End If
        Dim gbindex(count), gbindex2(count), big5index(count), big5index2(count) As Int64
        Dim gblin, gblin2, big5lin, big5lin2 As Integer
        gblin = 0
        gblin2 = -2
        big5lin = 0
        big5lin2 = -2
        For i = gbhead To Len(gb)
            If gblin2 = count Then
                Exit For
            End If
            If Mid(gb, i, Len(bz1)) = bz1 And gblin < count Then
                gbindex(gblin) = i + Len(bz1)
                gblin = gblin + 1
            End If
            If Mid(gb, i, Len(bz2)) = bz2 And gblin2 < gblin Then
                If gblin2 >= 0 Then
                    gbindex2(gblin2) = i
                    gblin2 = gblin2 + 1
                Else
                    gblin2 = gblin2 + 1
                End If
            End If
        Next
        For i = big5head To Len(big5)
            If big5lin2 = count Then
                Exit For
            End If
            If Mid(big5, i, Len(bz1)) = bz1 And big5lin < count Then
                big5index(big5lin) = i + Len(bz1)
                big5lin = big5lin + 1
            End If
            If Mid(big5, i, Len(bz2)) = bz2 And big5lin2 < big5lin Then
                If big5lin2 >= 0 Then
                    big5index2(big5lin2) = i
                    big5lin2 = big5lin2 + 1
                Else
                    big5lin2 = big5lin2 + 1
                End If
            End If
        Next
        If ZMTBIG5.Checked = True Then
            sc = Mid(big5, 1, big5head) + Mid(gb, gbhead + 1, gbindex(0) - gbhead - 1) + Th(Mid(big5, big5index(0), big5index2(0) - big5index(0)), Mid(gb, gbindex(0), gbindex2(0) - gbindex(0)), XGGB.Checked, 1, BIG5File, GBFile)
        Else
            sc = Mid(gb, 1, gbindex(0) - 1) + Th(Mid(big5, big5index(0), big5index2(0) - big5index(0)), Mid(gb, gbindex(0), gbindex2(0) - gbindex(0)), XGGB.Checked, 1, BIG5File, GBFile)
        End If
        For i = 1 To count - 1
            sc = sc + Mid(gb, gbindex2(i - 1), gbindex(i) - gbindex2(i - 1)) + Th(Mid(big5, big5index(i), big5index2(i) - big5index(i)), Mid(gb, gbindex(i), gbindex2(i) - gbindex(i)), XGGB.Checked, i + 1, BIG5File, GBFile)
        Next
        If gbcount >= big5count Then
            sc = sc + bz2 + Mid(gb, gbindex2(count - 1) + 1)
        Else
            sc = sc + bz2 + Mid(big5, big5index2(count - 1) + 1)
        End If
        Print(3, sc)
        FileClose(3)
        gbinput.Close()
        big5input.Close()
        If war Then waring += "——————————————————————" + vbCrLf + "——————————————————————" + vbCrLf
        Return 0
    End Function
    Function Th(strbig5 As String, strgb As String, tx As Boolean, line As Int64, BIG5File As String, GBFile As String) As String
        Dim sc1 As String = "", count, gbcount, big5count As Integer
        If tx = True Then
            For i = 1 To Len(strgb)
                If Mid(strgb, i, Len(bz3)) = bz3 Then
                    gbcount = gbcount + 1
                End If
            Next
            For i = 1 To Len(strbig5)
                If Mid(strbig5, i, Len(bz3)) = bz3 Then
                    big5count = big5count + 1
                End If
            Next
            If gbcount <> big5count Then
                If Not war Then
                    waring = waring + "GB文件: " + GBFile + vbCrLf + "BIG5文件: " + BIG5File + vbCrLf + vbCrLf
                    war = True
                Else
                    waring = waring + "—————————" + vbCrLf
                End If
                If gbcount <> 0 And big5count <> 0 Then
                    waring = waring + "***第【 " + line.ToString + " 】行GB与BIG5{\字幕效果}数量不一致***" + vbCrLf + "    GB: " + strgb.Substring(1) + vbCrLf + "    BIG5: " + strbig5.Substring(1) + vbCrLf
                Else
                    If gbcount = 0 Then
                        waring = waring + "第【 " + line.ToString + " 】行BIG5存在{\字幕效果}但GB不存在" + vbCrLf + "    GB: " + strgb.Substring(1) + vbCrLf + "    BIG5: " + strbig5.Substring(1) + vbCrLf
                    Else
                        waring = waring + "第【 " + line.ToString + " 】行GB存在{\字幕效果}但BIG5不存在" + vbCrLf + "    GB: " + strgb.Substring(1) + vbCrLf + "    BIG5: " + strbig5.Substring(1) + vbCrLf
                    End If
                End If
            End If
            count = Math.Min(gbcount, big5count)
            Dim gbindex(gbcount), gbindex2(gbcount), big5index(big5count), big5index2(big5count) As Integer
            Dim gblin, gblin2, big5lin, big5lin2 As Integer
            gblin = 0
            gblin2 = 0
            big5lin = 0
            big5lin2 = 0
            For i = 1 To Len(strgb)
                If gblin2 = gbcount Then
                    Exit For
                End If
                If Mid(strgb, i, Len(bz3)) = bz3 Then
                    gbindex(gblin) = i + Len(bz3)
                    gblin = gblin + 1
                End If
                If Mid(strgb, i, Len(bz4)) = bz4 Then
                    gbindex2(gblin2) = i
                    gblin2 = gblin2 + 1
                End If
            Next
            For i = 1 To Len(strbig5)
                If big5lin2 = big5count Then
                    Exit For
                End If
                If Mid(strbig5, i, Len(bz3)) = bz3 Then
                    big5index(big5lin) = i + Len(bz3)
                    big5lin = big5lin + 1
                End If
                If Mid(strbig5, i, Len(bz4)) = bz4 Then
                    big5index2(big5lin2) = i
                    big5lin2 = big5lin2 + 1
                End If
            Next
            If count > 0 Then
                sc1 = Mid(strbig5, 1, big5index(0) - 1) + Mid(strgb, gbindex(0), gbindex2(0) - gbindex(0))
                For i = 1 To count - 1
                    sc1 = sc1 + Mid(strbig5, big5index2(i - 1), big5index(i) - big5index2(i - 1)) + Mid(strgb, gbindex(i), gbindex2(i) - gbindex(i))
                Next
                sc1 = sc1 + bz4
                For i = count To gbcount - 1
                    sc1 = sc1 + bz3 + Mid(strgb, gbindex(i), gbindex2(i) - gbindex(i)) + bz4
                Next
                sc1 = sc1 + Mid(strbig5, big5index2(big5count - 1) + 1)
            Else
                If big5count = 0 And gbcount = 0 Then
                    sc1 = strbig5
                Else
                    If gbcount > 0 Then
                        Dim dhwz As Integer = 0
                        For i = 1 To Len(strbig5)
                            If Mid(strbig5, i, Len(",")) = "," Then
                                dhwz = i
                            End If
                        Next
                        sc1 = Mid(strbig5, 1, dhwz)
                        For i = 0 To gbcount - 1
                            sc1 = sc1 + bz3 + Mid(strgb, gbindex(i), gbindex2(i) - gbindex(i)) + bz4
                        Next
                        sc1 = sc1 + Mid(strbig5, dhwz + 1)
                    Else
                        sc1 = Mid(strbig5, 1, big5index(0) - 2)
                        sc1 = sc1 + Mid(strbig5, big5index2(big5count - 1) + 1)
                    End If
                End If
            End If
        Else
            sc1 = strbig5
        End If
        Return sc1
    End Function

    Private Sub OutFile_Click(sender As Object, e As EventArgs) Handles OutFile.Click
        Dim mystream As System.IO.Stream
        SaveFileDialog1.InitialDirectory = "\"
        SaveFileDialog1.CheckFileExists = False
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "ass文件(*.ass)|*.ass|所有文件(*.*)|*.*"
        SaveFileDialog1.Title = "保存输出字幕"
        SaveFileDialog1.RestoreDirectory = True
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Out.Text = SaveFileDialog1.FileName
            If Not (mystream Is Nothing) Then
                MessageBox.Show(mystream.Length.ToString)
                mystream.Close()
            End If
        End If
    End Sub

    Private Sub GBFile_Click(sender As Object, e As EventArgs) Handles GBFile.Click
        Dim mystream As System.IO.Stream
        OpenFileDialog1.InitialDirectory = "\"
        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "ass文件(*.ass)|*.ass|所有文件(*.*)|*.*"
        OpenFileDialog1.Title = "打开GB字幕文件"
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            GBin.Text = OpenFileDialog1.FileName
            If Not (mystream Is Nothing) Then
                MessageBox.Show(mystream.Length.ToString)
                mystream.Close()
            End If
        End If
    End Sub

    Private Sub BIG5File_Click(sender As Object, e As EventArgs) Handles BIG5File.Click
        Dim mystream As System.IO.Stream
        OpenFileDialog1.InitialDirectory = "\"
        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "ass文件(*.ass)|*.ass|所有文件(*.*)|*.*"
        OpenFileDialog1.Title = "打开BIG5字幕文件"
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            BIG5in.Text = OpenFileDialog1.FileName
            If Not (mystream Is Nothing) Then
                MessageBox.Show(mystream.Length.ToString)
                mystream.Close()
            End If
        End If
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        ChangeSize()
    End Sub

    Function ChangeSize() As Integer
        If Me.Visible And Me.WindowState <> WindowState.Minimized = True Then
            Dim a As Point, b As Size
            a.X = Me.Size.Width - 74
            a.Y = GBFile.Location.Y
            GBFile.Location = a
            a.Y = BIG5File.Location.Y
            BIG5File.Location = a
            a.Y = OutFile.Location.Y
            OutFile.Location = a
            b.Width = a.X - GBin.Location.X - 4
            b.Height = GBin.Size.Height
            GBin.Size = b
            BIG5in.Size = b
            Out.Size = b
            a.X = Math.Max((Me.Size.Width - Button1.Size.Width) / 2, 280)
            a.Y = 180
            Button1.Location = a
            If Detail.Visible = True Then
                If detailapp = True Then
                    b.Width = 8192
                    b.Height = MeHeightdef + DetailText.Size.Height
                    Me.MaximumSize = b
                    a.X = 0
                    a.Y = Detail.Location.Y + Detail.Size.Height
                    DetailText.Location = a
                    b.Width = Me.Width - 15
                    b.Height = DetailText.Size.Height
                    DetailText.Size = b
                    b.Width = Me.Width
                    b.Height = MeHeightdef + DetailText.Height
                    Me.Size = b
                    a.X = Me.Size.Width - Detail.Width - 15
                    a.Y = Me.Size.Height - Detail.Height - DetailText.Size.Height - 38
                    Detail.Location = a
                Else
                    b.Width = 8192
                    b.Height = MeHeightdef
                    Me.MaximumSize = b
                    b.Width = Me.Width
                    b.Height = MeHeightdef
                    Me.Size = b
                    a.X = Me.Size.Width - Detail.Width - 15
                    a.Y = Me.Size.Height - Detail.Height - 38
                    Detail.Location = a
                End If
            Else
                b.Width = Me.Width
                b.Height = MeHeightdef
                Me.Size = b
                b.Width = 8192
                b.Height = MeHeightdef
                Me.MaximumSize = b
            End If
        End If
        Return 0
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        GBin.AllowDrop = True
        BIG5in.AllowDrop = True
        Out.AllowDrop = True
        Dim MeSize As Size
        MeSize.Width = 673
        MeSize.Height = MeHeightdef
        Me.Size = MeSize
        MeSize.Width = 8192
        MeSize.Height = MeHeightdef + DetailText.Size.Height
        Me.MaximumSize = MeSize
    End Sub

    Private Sub Detail_Click(sender As Object, e As EventArgs) Handles Detail.Click
        If detailapp = True Then
            detailapp = False
            Detail.Text = "▼显示详情"
        Else
            detailapp = True
            Detail.Text = "▲隐藏详情"
        End If
        ChangeSize()
    End Sub

    Private Sub GBin_DragDrop(sender As Object, e As DragEventArgs) Handles GBin.DragDrop
        Dim filestr As String()
        filestr = e.Data.GetData(DataFormats.FileDrop)
        GBin.Text = filestr(0)
    End Sub

    Private Sub GBin_DragEnter(sender As Object, e As DragEventArgs) Handles GBin.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Link
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub BIG5in_DragEnter(sender As Object, e As DragEventArgs) Handles BIG5in.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Link
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub BIG5in_DragDrop(sender As Object, e As DragEventArgs) Handles BIG5in.DragDrop
        Dim filestr As String()
        filestr = e.Data.GetData(DataFormats.FileDrop)
        BIG5in.Text = filestr(0)
    End Sub

    Private Sub Out_DragEnter(sender As Object, e As DragEventArgs) Handles Out.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Link
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Out_DragDrop(sender As Object, e As DragEventArgs) Handles Out.DragDrop
        Dim filestr As String()
        filestr = e.Data.GetData(DataFormats.FileDrop)
        Out.Text = filestr(0)
    End Sub

    Private Sub GBFile_MouseDown(sender As Object, e As MouseEventArgs) Handles GBFile.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim input As IO.StreamReader
            Try
                input = New IO.StreamReader(GBin.Text, System.Text.Encoding.GetEncoding("unicode"))
            Catch ex As Exception
                MessageBox.Show("指定文件无法访问，请检查文件路径及可访问性！")
                Exit Sub
            End Try
            input.Close()
            Shell("explorer.exe /n," + GBin.Text)
        End If
    End Sub

    Private Sub BIG5File_MouseDown(sender As Object, e As MouseEventArgs) Handles BIG5File.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim input As IO.StreamReader
            Try
                input = New IO.StreamReader(BIG5in.Text, System.Text.Encoding.GetEncoding("unicode"))
            Catch ex As Exception
                MessageBox.Show("指定文件无法访问，请检查文件路径及可访问性！")
                Exit Sub
            End Try
            input.Close()
            Shell("explorer.exe /n," + BIG5in.Text)
        End If
    End Sub

    Private Sub OutFile_MouseDown(sender As Object, e As MouseEventArgs) Handles OutFile.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim input As IO.StreamReader
            Try
                input = New IO.StreamReader(Out.Text, System.Text.Encoding.GetEncoding("unicode"))
            Catch ex As Exception
                MessageBox.Show("指定文件无法访问，请检查文件路径及可访问性！")
                Exit Sub
            End Try
            input.Close()
            Shell("explorer.exe /n," + Out.Text)
        End If
    End Sub

End Class
