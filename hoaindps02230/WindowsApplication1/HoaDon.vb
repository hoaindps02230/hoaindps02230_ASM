Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class HoaDon
    Dim chuoilienket As String = "workstation id=hoaindps02230.mssql.somee.com;packet size=4096;user id=hoaindps02230_SQLLogin_1;pwd=nj6iu6wtwu;data source=hoaindps02230.mssql.somee.com;persist security info=False;initial catalog=hoaindps02230"
    Dim KetNoi As SqlConnection = New SqlConnection(chuoilienket)
    Dim table As New DataTable
    Private Sub TàiKhoảnToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TaiKhoan.Show()
    End Sub
    Public Sub LoadData()
        Dim sqladapter As New SqlDataAdapter("select * from HoaDon", KetNoi)
        Try
            sqladapter.Fill(table)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = table
        KetNoi.Close()
    End Sub
    Public Sub LoadDataSearch()
        Dim sqladapter As New SqlDataAdapter("select * from HoaDon where MaHD ='" & TextBox1.Text & "' or NhanVien_MaNV='" & TextBox2.Text & "' or KhachHang_MaKH='" & TextBox3.Text & "'", KetNoi)
        Try
            sqladapter.Fill(table)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = table
        KetNoi.Close()
    End Sub
    Private Sub QuảnLýSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs)
        SanPham.Show()
        Me.Hide()

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

    Private Sub QuảnLýSảnPhẩmToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles QuảnLýSảnPhẩmToolStripMenuItem.Click
        SanPham.Show()
        Me.Hide()

    End Sub

    Private Sub QuảnLýHóaĐơnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýHóaĐơnToolStripMenuItem.Click
    End Sub

    Private Sub QuảnLýKháchHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýKháchHàngToolStripMenuItem.Click
        KhachHang.Show()
        Me.Hide()

    End Sub

    Private Sub QuảnLýNhânViênToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýNhânViênToolStripMenuItem.Click
        NhanVien.Show()
        Me.Hide()

    End Sub

    Private Sub ThôngTinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThôngTinToolStripMenuItem.Click
        ThongTin.Show()
        Me.Hide()

    End Sub

    Private Sub HoaDon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqladapter As New SqlDataAdapter("select * from HoaDon", KetNoi)
        Try
            KetNoi.Open()
            sqladapter.Fill(table)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = table
        KetNoi.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqladapter As New SqlDataAdapter("select * from HoaDon", KetNoi)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        hoadon1.Show()
        KetNoi.Open()
        Dim manv As New SqlCommand("select MaNV from NhanVien where username = '" & Login.tendangnhap & "'", KetNoi)
        Dim manvt As Object = manv.ExecuteScalar()
        hoadon1.TextBox3.Text = manvt.ToString
        KetNoi.Close()
        hoadon1.TextBox3.Enabled = False
        hoadon1.Button2.Enabled = False
        hoadon1.Button1.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        KetNoi.Open()
        Dim dieukien As Integer = DataGridView1.CurrentCell.RowIndex
        Dim dk As String = DataGridView1.Item(0, dieukien).Value
        Dim xoa As String = "Delete from HoaDon where MaHD = @MaHD"
        Dim com As New SqlCommand(xoa, KetNoi)
        Try
            com.Parameters.AddWithValue("@MaHD", dk)
            com.ExecuteNonQuery()
            KetNoi.Close()
        Catch ex As Exception
        End Try
        table.Clear()
        DataGridView1.DataSource = table
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        hoadon1.Show()
        hoadon1.TextBox1.Enabled = False
        hoadon1.TextBox3.Enabled = False
        hoadon1.Button1.Enabled = False
        hoadon1.Button2.Enabled = True
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim click As Integer = DataGridView1.CurrentCell.RowIndex
        hoadon1.TextBox1.Text = DataGridView1.Item(0, click).Value
        hoadon1.TextBox2.Text = DataGridView1.Item(1, click).Value
        hoadon1.TextBox3.Text = DataGridView1.Item(2, click).Value
        hoadon1.TextBox4.Text = DataGridView1.Item(3, click).Value
        hoadon1.TextBox5.Text = DataGridView1.Item(4, click).Value
        hoadon1.TextBox6.Text = DataGridView1.Item(5, click).Value
        hoadon1.TextBox8.Text = DataGridView1.Item(6, click).Value
        hoadon1.TextBox7.Text = DataGridView1.Item(7, click).Value
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim timkiem As New SqlDataAdapter("select * from HoaDon where MaHD ='" & TextBox1.Text & "' or NhanVien_MaNV='" & TextBox2.Text & "' or KhachHang_MaKH='" & TextBox3.Text & "'", KetNoi)
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