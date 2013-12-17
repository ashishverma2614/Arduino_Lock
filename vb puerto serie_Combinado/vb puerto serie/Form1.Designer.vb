<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.abrir_puerto = New System.Windows.Forms.Button()
        Me.cerrar_puerto = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.USUARIO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FECHA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SerialPort2 = New System.IO.Ports.SerialPort(Me.components)
        Me.SuspendLayout()
        '
        'abrir_puerto
        '
        Me.abrir_puerto.Location = New System.Drawing.Point(232, 42)
        Me.abrir_puerto.Name = "abrir_puerto"
        Me.abrir_puerto.Size = New System.Drawing.Size(84, 57)
        Me.abrir_puerto.TabIndex = 0
        Me.abrir_puerto.Text = "Abrir puerto"
        Me.abrir_puerto.UseVisualStyleBackColor = True
        '
        'cerrar_puerto
        '
        Me.cerrar_puerto.Location = New System.Drawing.Point(599, 42)
        Me.cerrar_puerto.Name = "cerrar_puerto"
        Me.cerrar_puerto.Size = New System.Drawing.Size(92, 57)
        Me.cerrar_puerto.TabIndex = 1
        Me.cerrar_puerto.Text = "Cerrar puerto"
        Me.cerrar_puerto.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM3"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.USUARIO, Me.FECHA})
        Me.ListView1.Location = New System.Drawing.Point(126, 133)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(646, 355)
        Me.ListView1.TabIndex = 6
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'USUARIO
        '
        Me.USUARIO.Text = "USUARIO"
        Me.USUARIO.Width = 200
        '
        'FECHA
        '
        Me.FECHA.Text = "FECHA"
        Me.FECHA.Width = 500
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(778, 133)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 85)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SerialPort2
        '
        Me.SerialPort2.PortName = "COM4"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 523)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.cerrar_puerto)
        Me.Controls.Add(Me.abrir_puerto)
        Me.Name = "Form1"
        Me.Text = "CONTROL PRINCIPAL"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents abrir_puerto As System.Windows.Forms.Button
    Friend WithEvents cerrar_puerto As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents USUARIO As System.Windows.Forms.ColumnHeader
    Friend WithEvents FECHA As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SerialPort2 As System.IO.Ports.SerialPort

End Class
