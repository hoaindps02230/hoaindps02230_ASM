Imports System.Data.SqlClient
Public Class Main
    Dim chuoilienket As String = "workstation id=hoaindps02230.mssql.somee.com;packet size=4096;user id=hoaindps02230_SQLLogin_1;pwd=nj6iu6wtwu;data source=hoaindps02230.mssql.somee.com;persist security info=False;initial catalog=hoaindps02230"
    Dim KetNoi As SqlConnection = New SqlConnection(chuoilienket)
    Private Sub HToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HToolStripMenuItem.Click

    End Sub

    Private Sub QuảnLýToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýToolStripMenuItem.Click
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
        NhanVien.Show()
        Me.Hide()
    End Sub

    Private Sub TàiKhoảnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TàiKhoảnToolStripMenuItem.Click
        TaiKhoan.Show()
        Me.Hide()
    End Sub


    Private Sub ThôngTinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThôngTinToolStripMenuItem.Click
        ThongTin.Show()
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

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class