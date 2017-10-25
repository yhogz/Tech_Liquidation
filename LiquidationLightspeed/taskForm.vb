Public Class taskForm

    Private Sub btnLiquidation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiquidation.Click
        Me.Hide()
        liquidationLoggerForm.Show()

    End Sub

    Private Sub btnTechActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTechActivity.Click

        Me.Hide()
        Cursor.Current = Cursors.WaitCursor
        techActivityForm.Show()

    End Sub

    Private Sub btnJRFGeneration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJRFGeneration.Click
        Me.Hide()
        generationForm.Show()

    End Sub
End Class