Imports BattleNET

Public Class MessageTest
    Private tc As tcp_client
    Dim ConnInfo As String = "Server=167.114.28.196;userid=PGC_Tools;password=!!;port=3306;database=arma5life"


    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshListToolStripMenuItem.Click
        lvBEPlayersOn.Items.Clear()
    End Sub

    Private Sub MessageTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

