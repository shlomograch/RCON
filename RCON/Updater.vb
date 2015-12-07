Public Class Updater
    Private _client As tcp_client
    Public Sub CheckForUpdates()
        If ProgressBar1.Value = 100 Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://www.dropbox.com/s/wmajhmg9evj7ooe/Version.txt?dl=0")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            If newestversion.Contains(currentversion) Then
                Button1.Text = ("You are up todate!")
                Button2.Visible = True

            Else
                Button1.Text = ("Downloading update!")
                WebBrowser1.Navigate("https://www.dropbox.com/s/4bs0rwj6pqkdw7k/RCON.exe?dl=0")
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        Label1.Text = ProgressBar1.Value
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            If ProgressBar1.Value = 100 Then
                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://www.dropbox.com/s/wmajhmg9evj7ooe/Version.txt?dl=0")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Dim newestversion As String = sr.ReadToEnd()
                Dim currentversion As String = Application.ProductVersion
                If newestversion.Contains(currentversion) Then
                    Button1.Text = ("You are up todate!")
                    Button2.Visible = True
                Else
                    Button1.Text = ("Downloading update!")
                    WebBrowser1.Navigate("https://www.dropbox.com/s/4bs0rwj6pqkdw7k/RCON.exe?dl=1")
                End If
            End If
        End If
    End Sub

    Private Sub Updater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainPage.Show()
        Me.MaximizeBox = False
        Button1.Enabled = False
        Button2.Visible = False
        Button1.Text = "Checking for updates..."
        Timer1.Start()
        Label1.Text = ProgressBar1.Value
        CheckForUpdates()
        RichTextBox1.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Calibri;}}{\*\generator Riched20 6.3.9600}\viewkind4\uc1 \pard\sa200\sl276\slmult1\b\f0\fs22\lang9V1.0.1.8\par\b0 - Critical update to compensation log (it works now) \b\par v1.0.1.7\par\b0 - Vehicle garage list now fully functional\par\b0 - Adding vehicles now operational\par\b0 - Removing vehicles now enabled and operational\par\b0 - Removed check boxes: Kick/Ban Player, Server Console, Settings and replaced with Logs and betaforms\par\b0 - Fixed Cop white listing and medic white listing for admin level 0's with a cop/medic level of 1 (Chief of Police and Chief Medical Officer)\par\b0 - GUID Thumbprinting enabled so that connections from different computers that use the same login info will be flagged\par\b0 - SHA256RAC Encryption added to strings for secure connections\par\par \b v1.0.1.6 \par\b0 - Bug fix for Mysql.Data importation bug\par\b0 - Enabled text boxes under compensation tab for users to be able to copy players GUID and Username\par\b0 - Bug fixes for Admin levels (Certain administrative accounts had no access to any of the options)\par\b0 - Various other minor bug fixes such as connection issues and program stability\par\b0 - Bug fix on vehicle compensation -- Adding vehicles now works properly, next patch will have the remove vehicles working correctly.\par\par\b v1.0.1.3 \par\b0 - Updated name from Phantom RCON -> Phantom Tools\par\b0 - Added connection to VPS for Tools\par\b0 - Level 1 administrators (Normal Admins) are now restricted to only being able to give vehicles, Cash on hand and Ban account updates.\par\b0 - Updated Encryption Methods to use  more secure connection between DB and Client\b\parv1.0.1.2 \par\b0 - Updated Logo\par\b0 - Auto Updater added so that the program will always stay up to date instead of having to check for updates\par\b - \b0 Added changelog so that users will know what is being updated with the program.\par}"

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PGC_RCON_LOGIN.Show()
        Me.Close()

    End Sub
End Class
