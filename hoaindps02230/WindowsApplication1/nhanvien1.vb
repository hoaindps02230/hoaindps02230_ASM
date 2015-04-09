Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class nhanvien1
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
        NhanVien.DataGridView1.DataSource = table
        KetNoi.Close()
    End Sub
    Public Sub LoadDataMaPhongBang()
        Dim sqladapter As New SqlDataAdapter("select * from PhongBang", KetNoi)
        Try
            sqladapter.Fill(table1)
        Catch ex As Exception

        End Try
        DataGridView2.DataSource = table1
        KetNoi.Close()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        NhanVien.Show()
        Me.Hide()
        TextBox1.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        KetNoi.Open()
        Dim them As String = "insert into NhanVien values (@MaNV,@PhongBang_MaPB,@HoTen,@GioiTinh,@DiaChi,@Email,@SoDienThoai,@username,@password)"
        Dim cmd As SqlCommand = New SqlCommand(them, KetNoi)
        Try
            cmd.Parameters.AddWithValue("@MaNV", TextBox1.Text)
            cmd.Parameters.AddWithValue("@PhongBang_MaPB", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@HoTen", TextBox3.Text)
            cmd.Parameters.AddWithValue("@GioiTinh", ComboBox2.Text)
            cmd.Parameters.AddWithValue("@DiaChi", TextBox5.Text)
            cmd.Parameters.AddWithValue("@Email", TextBox6.Text)
            cmd.Parameters.AddWithValue("@SoDienThoai", TextBox7.Text)
            cmd.Parameters.AddWithValue("@username", TextBox8.Text)
            cmd.Parameters.AddWithValue("@password", TextBox9.Text)
            cmd.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Thành Công")
        Catch ex As Exception
            If TextBox1.Text = "" Then
                MessageBox.Show("Chưa nhập Mã Nhân Viên")
            ElseIf ComboBox1.Text = "" Then
                MessageBox.Show("Chưa chọn Mã Phòng Bang")
            ElseIf TextBox3.Text = "" Then
                MessageBox.Show("Chưa nhập Họ Tên")
            ElseIf TextBox8.Text = "" Then
                MessageBox.Show("Chưa Nhập Username")
            ElseIf TextBox9.Text = "" Then
                MessageBox.Show("Chưa Nhập Password")
            End If
        End Try
        TextBox1.Clear()
        TextBox3.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        table.Clear()
        NhanVien.DataGridView1.DataSource = table
        NhanVien.DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        KetNoi.Open()
        Dim sua As String = "UPDATE NhanVien SET HoTen = @HoTen, GioiTinh = @GioiTinh, DiaChi = @DiaChi, Email = @Email, SoDienThoai = @SoDienThoai, username = @username, password = @password where MaNV = @MaNV"
        Dim sua1 As New SqlCommand(sua, KetNoi)
        Try
            sua1.Parameters.AddWithValue("@MaNV", TextBox1.Text)
            sua1.Parameters.AddWithValue("@HoTen", TextBox3.Text)
            sua1.Parameters.AddWithValue("@GioiTinh", ComboBox2.Text)
            sua1.Parameters.AddWithValue("@DiaChi", TextBox5.Text)
            sua1.Parameters.AddWithValue("@Email", TextBox6.Text)
            sua1.Parameters.AddWithValue("@SoDienThoai", TextBox7.Text)
            sua1.Parameters.AddWithValue("@username", TextBox8.Text)
            sua1.Parameters.AddWithValue("@password", TextBox9.Text)
            sua1.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Thành Công")
        Catch ex As Exception
            MessageBox.Show("Sửa không thành công")
        End Try
        table.Clear()
        NhanVien.DataGridView1.DataSource = table
        NhanVien.DataGridView1.DataSource = Nothing
        LoadData()
        Me.Hide()
        TextBox1.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1

    End Sub

    Private Sub nhanvien1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqladapter As New SqlDataAdapter("select * from PhongBang", KetNoi)
        Try
            KetNoi.Open()
            sqladapter.Fill(table1)
        Catch ex As Exception

        End Try
        DataGridView2.DataSource = table1
        KetNoi.Close()
        KetNoi.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select * from PhongBang", KetNoi)
        Dim rd As SqlDataReader = cmd.ExecuteReader()
        While rd.Read
            ComboBox1.Items.Add(rd.GetValue(0).ToString)
        End While
        rd.Close()
        KetNoi.Close()
        table1.Clear()
        DataGridView2.DataSource = table1
        DataGridView2.DataSource = Nothing
        LoadDataMaPhongBang()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        KetNoi.Open()
        Dim them As String = "insert into PhongBang values (@MaPB,@TenPB)"
        Dim cmd As SqlCommand = New SqlCommand(them, KetNoi)
        Try
            cmd.Parameters.AddWithValue("@MaPB", TextBox18.Text)
            cmd.Parameters.AddWithValue("@TenPB", TextBox17.Text)
            cmd.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Thêm thành công mã phong bang " & TextBox18.Text & "")
        Catch ex As Exception
        End Try
        TextBox18.Clear()
        TextBox17.Clear()
        table1.Clear()
        DataGridView2.DataSource = table1
        DataGridView2.DataSource = Nothing
        LoadDataMaPhongBang()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        KetNoi.Open()
        Dim them As String = "insert into NhanVien values (@MaNV,@PhongBang_MaPB,@HoTen,@GioiTinh,@DiaChi,@Email,@SoDienThoai,@username,@password)"
        Dim cmd As SqlCommand = New SqlCommand(them, KetNoi)
        Try
            cmd.Parameters.AddWithValue("@MaNV", TextBox1.Text)
            cmd.Parameters.AddWithValue("@PhongBang_MaPB", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@HoTen", TextBox3.Text)
            cmd.Parameters.AddWithValue("@GioiTinh", ComboBox2.Text)
            cmd.Parameters.AddWithValue("@DiaChi", TextBox5.Text)
            cmd.Parameters.AddWithValue("@Email", TextBox6.Text)
            cmd.Parameters.AddWithValue("@SoDienThoai", TextBox7.Text)
            cmd.Parameters.AddWithValue("@username", TextBox8.Text)
            cmd.Parameters.AddWithValue("@password", TextBox9.Text)
            cmd.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Thành Công")
        Catch ex As Exception
            If TextBox1.Text = "" Then
                MessageBox.Show("Chưa nhập Mã Nhân Viên")
            ElseIf ComboBox1.Text = "" Then
                MessageBox.Show("Chưa chọn Mã Phòng Bang")
            ElseIf TextBox3.Text = "" Then
                MessageBox.Show("Chưa nhập Họ Tên")
            ElseIf TextBox8.Text = "" Then
                MessageBox.Show("Chưa Nhập Username")
            ElseIf TextBox9.Text = "" Then
                MessageBox.Show("Chưa Nhập Password")
            End If
        End Try
        TextBox1.Clear()
        TextBox3.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        table.Clear()
        NhanVien.DataGridView1.DataSource = table
        NhanVien.DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        KetNoi.Open()
        Dim sua As String = "UPDATE PhongBang SET TenPB = @TenPB where MaPB = @MaPB"
        Dim com As New SqlCommand(sua, KetNoi)
        Try
            com.Parameters.AddWithValue("@TenPB", TextBox17.Text)
            com.Parameters.AddWithValue("@MaPB", TextBox18.Text)
            com.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Sửa thành công sản phẩm có mã loại " & TextBox18.Text & "")
        Catch ex As Exception
            MessageBox.Show("Không")
        End Try
        table1.Clear()
        DataGridView2.DataSource = table1
        DataGridView2.DataSource = Nothing
        LoadDataMaPhongBang()
        TextBox17.Clear()
        TextBox18.Clear()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        KetNoi.Open()
        Dim dieukien As Integer = DataGridView2.CurrentCell.RowIndex
        Dim dk As String = DataGridView2.Item(0, dieukien).Value
        Dim xoa As String = "Delete from PhongBang where MaPB = @MaPB"
        Dim com As New SqlCommand(xoa, KetNoi)
        Try
            com.Parameters.AddWithValue("@MaPB", dk)
            com.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Bạn có muốn xóa sản phẩm")
            Button10.Enabled = True
            TextBox18.Enabled = True
        Catch ex As Exception
        End Try
        table1.Clear()
        DataGridView2.DataSource = table1
        DataGridView2.DataSource = Nothing
        LoadDataMaPhongBang()
        TextBox18.Clear()
        TextBox17.Clear()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        KetNoi.Open()
        Dim sua As String = "UPDATE NhanVien SET HoTen = @HoTen, GioiTinh = @GioiTinh, DiaChi = @DiaChi, Email = @Email, SoDienThoai = @SoDienThoai, username = @username, password = @password where MaNV = @MaNV"
        Dim sua1 As New SqlCommand(sua, KetNoi)
        Try
            sua1.Parameters.AddWithValue("@MaNV", TextBox1.Text)
            sua1.Parameters.AddWithValue("@HoTen", TextBox3.Text)
            sua1.Parameters.AddWithValue("@GioiTinh", ComboBox2.Text)
            sua1.Parameters.AddWithValue("@DiaChi", TextBox5.Text)
            sua1.Parameters.AddWithValue("@Email", TextBox6.Text)
            sua1.Parameters.AddWithValue("@SoDienThoai", TextBox7.Text)
            sua1.Parameters.AddWithValue("@username", TextBox8.Text)
            sua1.Parameters.AddWithValue("@password", TextBox9.Text)
            sua1.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Thành Công")
        Catch ex As Exception
            MessageBox.Show("Sửa không thành công")
        End Try
        table.Clear()
        NhanVien.DataGridView1.DataSource = table
        NhanVien.DataGridView1.DataSource = Nothing
        LoadData()
        Me.Hide()
        TextBox1.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        NhanVien.Show()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class