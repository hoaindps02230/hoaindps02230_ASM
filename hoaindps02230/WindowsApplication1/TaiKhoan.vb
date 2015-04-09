Imports System.Data.SqlClient
Public Class TaiKhoan
    Dim chuoilienket As String = "workstation id=hoaindps02230.mssql.somee.com;packet size=4096;user id=hoaindps02230_SQLLogin_1;pwd=nj6iu6wtwu;data source=hoaindps02230.mssql.somee.com;persist security info=False;initial catalog=hoaindps02230"
    Dim KetNoi As SqlConnection = New SqlConnection(chuoilienket)
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main.Show()
        Me.Hide()
    End Sub

    Private Sub TaiKhoan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim manv As New SqlCommand("select MaNV from NhanVien where username = '" & Login.tendangnhap & "'", KetNoi)
        Dim mapb As New SqlCommand("select PhongBang_MaPB from NhanVien where username = '" & Login.tendangnhap & "'", KetNoi)
        Dim hoten As New SqlCommand("select HoTen from NhanVien where username = '" & Login.tendangnhap & "'", KetNoi)
        Dim gioitinh As New SqlCommand("select GioiTinh from NhanVien where username = '" & Login.tendangnhap & "'", KetNoi)
        Dim diachi As New SqlCommand("select DiaChi from NhanVien where username = '" & Login.tendangnhap & "'", KetNoi)
        Dim email As New SqlCommand("select Email from NhanVien where username = '" & Login.tendangnhap & "'", KetNoi)
        Dim sdt As New SqlCommand("select SoDienThoai from NhanVien where username = '" & Login.tendangnhap & "'", KetNoi)
        Dim username As New SqlCommand("select username from NhanVien where username = '" & Login.tendangnhap & "'", KetNoi)
        Dim password As New SqlCommand("select password from NhanVien where username = '" & Login.tendangnhap & "'", KetNoi)
        KetNoi.Open()
        Dim manvt As Object = manv.ExecuteScalar()
        Dim mapbt As Object = mapb.ExecuteScalar()
        Dim hotent As Object = hoten.ExecuteScalar()
        Dim gioitinht As Object = gioitinh.ExecuteScalar()
        Dim diachit As Object = diachi.ExecuteScalar()
        Dim emailt As Object = email.ExecuteScalar()
        Dim sdtt As Object = sdt.ExecuteScalar()
        Dim usernamet As Object = username.ExecuteScalar()
        Dim passwordt As Object = password.ExecuteScalar()
        TextBox1.Text = manvt.ToString
        TextBox2.Text = mapbt.ToString
        TextBox3.Text = hotent.ToString
        TextBox4.Text = gioitinht.ToString
        TextBox5.Text = diachit.ToString
        TextBox6.Text = emailt.ToString
        TextBox7.Text = sdtt.ToString
        TextBox8.Text = usernamet.ToString
        TextBox9.Text = passwordt.ToString
    End Sub
End Class