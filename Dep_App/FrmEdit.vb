Public Class FrmEdi




    Private Sub FrmEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtCost.Text = b_cost
        txtDescription.Text = b_description
        cmbType.Text = b_type


    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click



        Try
            frmMain.ListView1.SelectedItems.Item(0).Text = b_cost
            frmMain.ListView1.SelectedItems.Item(0).SubItems(1).Text = b_type
            frmMain.ListView1.SelectedItems.Item(0).SubItems(2).Text = b_description
        Catch ex As Exception

        End Try

    End Sub
End Class