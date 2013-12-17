Public Class Form1

    Dim contenido_fichero As String


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.ListView1.View = View.Details

        SerialPort1.Close()
        SerialPort1.PortName = "com3" ' TECLADO
        SerialPort1.BaudRate = 9600

        SerialPort2.Close()
        SerialPort2.PortName = "com4" ' TECLADO
        SerialPort2.BaudRate = 9600

        CheckForIllegalCrossThreadCalls = False

    End Sub

    Private Sub Form1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs)
        SerialPort1.Close()
        SerialPort2.Close()
    End Sub

    Private Sub abrir_puerto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abrir_puerto.Click

        SerialPort1.Open()
        SerialPort2.Open()

        abrir_puerto.Enabled = False



    End Sub

    Private Sub cerrar_puerto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cerrar_puerto.Click

        SerialPort1.Close()
        SerialPort2.Close()
        abrir_puerto.Enabled = True

    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        Dim a As String
        Dim i As ListViewItem
        Dim bytes_leidos(5) As Byte


        a = SerialPort1.ReadLine()
       

        If a = "1B" & vbCr & "" Or a = "1C" & vbCr & "" Then

            i = ListView1.Items.Add("MARIA/TECLADO")
            i.SubItems.Add(DateTime.Now)
            'archivo.writeline("mikel leonardo")


        ElseIf a = "2B" & vbCr & "" Or a = "2C" & vbCr & "" Then

            i = ListView1.Items.Add("ARRATE/TECLADO")
            i.SubItems.Add(DateTime.Now)
            'archivo.writeline("iñaki leonardo")

        ElseIf a = "3B" & vbCr & "" Or a = "3C" & vbCr & "" Then

            i = ListView1.Items.Add("AMAIA/TECLADO")
            i.SubItems.Add(DateTime.Now)
            'archivo.writeline("iñaki leonardo")

        ElseIf a.Contains("CC") Then

            Select Case a
                Case "CC1" & vbCr & ""
                    i = ListView1.Items.Add("MARIA CAMBIADO")
                    i.SubItems.Add(DateTime.Now)
                Case "CC2" & vbCr & ""
                    i = ListView1.Items.Add("ARRATE CAMBIADO")
                    i.SubItems.Add(DateTime.Now)
                Case "CC3" & vbCr & ""
                    i = ListView1.Items.Add("AMAIA CAMBIADO")
                    i.SubItems.Add(DateTime.Now)
                Case Else
                    i = ListView1.Items.Add("- CAMBIADO")
                    i.SubItems.Add(DateTime.Now)
            End Select

        ElseIf a = "1" & vbCr & "" Then

            i = ListView1.Items.Add("MIKEL/RFID")
            i.SubItems.Add(DateTime.Now)
            'archivo.writeline("mikel leonardo")

        ElseIf a = "2" & vbCr & "" Then

            i = ListView1.Items.Add("IÑAKI/RFID")
            i.SubItems.Add(DateTime.Now)
            'archivo.writeline("iñaki leonardo")

        ElseIf a = "AD" & vbCr & "" Then

            i = ListView1.Items.Add("ACCESO DENEGADO")
            i.SubItems.Add(DateTime.Now)
            ' archivo.writeline("acceso denegado")

        Else

            i = ListView1.Items.Add("CLAVE INCORRECTA")
            i.SubItems.Add(DateTime.Now)
            ' archivo.writeline("acceso denegado")
        End If
        'archivo.close()



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim contenido As String = ""
        Dim writer As IO.StreamWriter

        Try
            For Each item As ListViewItem In ListView1.Items
                contenido &= item.Text & vbTab & item.SubItems(1).Text & vbCrLf
            Next

            writer = New IO.StreamWriter("D:\fichero.txt", False)
            writer.Write(contenido)
            writer.Close()
        Catch ex As Exception
            MessageBox.Show("La escritura ha fallado" & vbCrLf & vbCrLf & ex.ToString)
        End Try

    End Sub

    Private Sub SerialPort2_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived

        Dim a As String
        Dim i As ListViewItem



        a = SerialPort2.ReadLine()


        If a = "x" & vbCr & "" Then

            i = ListView1.Items.Add("JON BT")
            i.SubItems.Add(DateTime.Now)
            'archivo.writeline("mikel leonardo")


        ElseIf a = "y" & vbCr & "" Then

            i = ListView1.Items.Add("MARCOS BT")
            i.SubItems.Add(DateTime.Now)
            'archivo.writeline("iñaki leonardo")

        ElseIf a = "w" & vbCr & "" Then

            i = ListView1.Items.Add("CABRIA BT")
            i.SubItems.Add(DateTime.Now)
            'archivo.writeline("iñaki leonardo")

        Else

            i = ListView1.Items.Add("CONTRASEÑA INCORRECTA BT")
            i.SubItems.Add(DateTime.Now)
            'archivo.writeline("iñaki leonardo")

        End If



    End Sub
End Class


