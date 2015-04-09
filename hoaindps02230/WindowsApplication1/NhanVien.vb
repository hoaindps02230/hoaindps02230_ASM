Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class NhanVien
    Dim chuoilienket As String = "workstation id=hoaindps02230.mssql.somee.com;packet size=4096;user id=hoaindps02230_SQLLogin_1;pwd=nj6iu6wtwu;data source=hoaindps02230.mssql.somee.com;persist security info=False;initial catalog=hoaindps02230"
    Dim KetNoi As SqlConnection = New SqlConnection(chuoilienket)
    Dim table As New DataTable
    Dim table1 As New DataTable
    Public Sub LoadData()
        Dim sqladapter As New SqlDataAdapter("select * from NhanVien", KetNoi)
        Try
            sqladapter.Fill(table)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = table
        KetNoi.Close()
    End Sub
    Public Sub LoadDataHD()
        Dim sqladapter As New SqlDataAdapter("select * from HoaDon", KetNoi)
        Try
            sqladapter.Fill(table1)
        Catch ex As Exception

        End Try
        HoaDon.DataGridView1.DataSource = table1
        KetNoi.Close()
    End Sub
    Public Sub LoadDataSearch()
        Dim sqladapter As New SqlDataAdapter("select * from NhanVien where MaNV = '" & TextBox1.Text & "' or HoTen = '" & TextBox2.Text & "' or Email = '" & TextBox3.Text & "' or PhongBang_MaPB = '" & ComboBox1.Text & "'", KetNoi)
        Try
            sqladapter.Fill(table)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = table
        KetNoi.Close()
    End Sub
    Private Sub TàiKhoảnToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TaiKhoan.Show()
    End Sub

    Private Sub TàiKhoảnToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles TàiKhoảnToolStripMenuItem.Click
        TaiKhoan.Show()
        Me.Hide()

    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Login.Show()
        Me.Hide()
        Login.user.Clear()
        Login.pass.Clear()

    End Sub

    Private Sub ThoátToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThoátToolStripMenuItem.Click
        End
    End Sub

    Private Sub QuảnLýSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýSảnPhẩmToolStripMenuItem.Click
        SanPham.Show()
        Me.Hide()

    End Sub

    Private Sub QuảnLýHóaĐơnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýHóaĐơnToolStripMenuItem.Click
        HoaDon.Show()
        Me.Hide()

    End Sub

    Private Sub QuảnLýKháchHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýKháchHàngToolStripMenuItem.Click
        KhachHang.Show()
        Me.Hide()

    End Sub

    Private Sub QuảnLýNhânViênToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýNhânViênToolStripMenuItem.Click

    End Sub

    Private Sub ThôngTinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThôngTinToolStripMenuItem.Click
        ThongTin.Show()
        Me.Hide()

    End Sub

    Private Sub NhanVien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub QuảnLýToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýToolStripMenuItem.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqladapter As New SqlDataAdapter("select * from NhanVien", KetNoi)
        Try
            KetNoi.Open()
            sqladapter.Fill(table)
        Catch ex As Exception

        End Try
        table.Clear()
        DataGridView1.DataSource = table
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim timkiem As New SqlDataAdapter("select * from NhanVien where MaNV='" & TextBox1.Text & "' or HoTen='" & TextBox2.Text & "' or Email='" & TextBox3.Text & "'or PhongBang_MaPB = '" & ComboBox1.Text & "'", KetNoi)
        Try
            KetNoi.Open()
            timkiem.Fill(table)
        Catch ex As Exception

        End Try
        table.Clear()
        DataGridView1.DataSource = table
        DataGridView1.DataSource = Nothing
        LoadDataSearch()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nhanvien1.Show()
        nhanvien1.Button2.Enabled = False
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        KetNoi.Open()
        Dim dieukien1 As Integer = DataGridView1.CurrentCell.RowIndex
        Dim dk1 As String = DataGridView1.Item(0, dieukien1).Value
        Dim xoa1 As String = "Delete from HoaDon where NhanVien_MaNV = @MaNV"
        Dim com1 As New SqlCommand(xoa1, KetNoi)
        Try
            com1.Parameters.AddWithValue("@MaNV", dk1)
            com1.ExecuteNonQuery()
            KetNoi.Close()
        Catch ex As Exception
        End Try
        table1.Clear()
        HoaDon.DataGridView1.DataSource = table1
        HoaDon.DataGridView1.DataSource = Nothing
        LoadDataHD()
        KetNoi.Open()
        Dim dieukien As Integer = DataGridView1.CurrentCell.RowIndex
        Dim dk As String = DataGridView1.Item(0, dieukien).Value
        Dim xoa As String = "Delete from NhanVien where MaNV = @MaNV"
        Dim com As New SqlCommand(xoa, KetNoi)
        Try
            com.Parameters.AddWithValue("@MaNV", dk)
            com.ExecuteNonQuery()
            KetNoi.Close()
        Catch ex As Exception
            MessageBox.Show("Xóa không thành công")
        End Try
        table.Clear()
        DataGridView1.DataSource = table
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nhanvien1.Show()
        nhanvien1.TextBox1.Enabled = False
        nhanvien1.Button1.Enabled = False
        nhanvien1.ComboBox1.Enabled = False
        nhanvien1.Button2.Enabled = True
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim click As Integer = DataGridView1.CurrentCell.RowIndex
        nhanvien1.TextBox1.Text = DataGridView1.Item(0, click).Value
        nhanvien1.ComboBox1.Text = DataGridView1.Item(1, click).Value
        nhanvien1.TextBox3.Text = DataGridView1.Item(2, click).Value
        nhanvien1.ComboBox2.Text = DataGridView1.Item(3, click).Value
        nhanvien1.TextBox5.Text = DataGridView1.Item(4, click).Value
        nhanvien1.TextBox6.Text = DataGridView1.Item(5, click).Value
        nhanvien1.TextBox7.Text = DataGridView1.Item(6, click).Value
        nhanvien1.TextBox8.Text = DataGridView1.Item(7, click).Value
        nhanvien1.TextBox9.Text = DataGridView1.Item(8, click).Value
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
        Dim mapb As New SqlCommand("select PhongBang_MaPB from NhanVien where username = '" & Login.tendangnhap & "'", KetNoi)
        KetNoi.Open()
        Dim mapbt As Object = mapb.ExecuteScalar()
        Dim dieukien As String = mapbt.ToString
        If dieukien = "KT" Then
            QuảnLýNhânViênToolStripMenuItem.Enabled = False
            QuảnLýHóaĐơnToolStripMenuItem.Enabled = True
            QuảnLýKháchHàngToolStripMenuItem.Enabled = False
            QuảnLýSảnPhẩmToolStripMenuItem.Enabled = False
        ElseIf dieukien = "NS" Then
            QuảnLýNhânViênToolStripMenuItem.Enabled = True
            QuảnLýHóaĐơnToolStripMenuItem.Enabled = False
            QuảnLýKháchHàngToolStripMenuItem.Enabled = False
            QuảnLýSảnPhẩmToolStripMenuItem.Enabled = False
        ElseIf dieukien = "KH" Then
            QuảnLýNhânViênToolStripMenuItem.Enabled = False
            QuảnLýHóaĐơnToolStripMenuItem.Enabled = False
            QuảnLýKháchHàngToolStripMenuItem.Enabled = True
            QuảnLýSảnPhẩmToolStripMenuItem.Enabled = False
        ElseIf dieukien = "BH" Then
            QuảnLýNhânViênToolStripMenuItem.Enabled = False
            QuảnLýHóaĐơnToolStripMenuItem.Enabled = False
            QuảnLýKháchHàngToolStripMenuItem.Enabled = False
            QuảnLýSảnPhẩmToolStripMenuItem.Enabled = True

        End If

        KetNoi.Close()
    End Sub
End Class