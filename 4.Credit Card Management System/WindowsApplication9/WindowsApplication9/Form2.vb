﻿Public Class Form2
    Dim con As System.Data.OleDb.OleDbConnection
    Dim cmd As System.Data.OleDb.OleDbCommand
    Dim dr As System.Data.OleDb.OleDbDataReader
    Dim sqlstr As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim un As String
        Dim ps As String
        un = TextBox1.Text()
        ps = TextBox2.Text()
        If (TextBox1.Text = " " Or TextBox2.Text = " ") Then
            MsgBox("Pls fill in the fields")
        End If
        con = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\cus55.mdb;Jet OLEDB:Database Password='';")
        con.Open()
        MsgBox("connection sucessful")
        If (TextBox1.Text = "" Or TextBox2.Text = "") Then
            MsgBox("Fields are not complete")
            GoTo l
        End If
        sqlstr = "select * from cus5 where username='" & un & "' and password='" & ps & "' "
        cmd = New OleDb.OleDbCommand(sqlstr, con)
        dr = cmd.ExecuteReader()
        Me.Hide()
        If dr.HasRows = True Then
            Form6.Show()
            While dr.Read
                Form6.TextBox1.Text = dr(6)
                Form6.TextBox2.Text = dr(0)
                Form6.TextBox3.Text = dr(2)
                Form6.TextBox4.Text = dr(1)
                Form7.TextBox2.Text = dr(1)
                Form8.TextBox2.Text = dr(1)
            End While
            GoTo b
        Else
            MsgBox("username and password does not match, try again")
            GoTo l
        End If
l:      Me.Show()
b:
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class