Imports System.Configuration
Imports System.Net
Imports System.Net.Mail
Imports System.ServiceModel
Imports System.Text

Public Class Caronte

    Private AppProxy As wsCaronte.IwsCaronteClient
    Private AppGen As AppGeneral.AppGeneral
    Private Compresion As AppCompresion.AppCompresion
    Private objMutex As System.Threading.Mutex
    Private SmtpServidor As SmtpClient

    Private Sub Caronte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        objMutex = New System.Threading.Mutex(False, "Caronte")

        If objMutex.WaitOne(0, False) = False Then
            objMutex.Close()
            objMutex = Nothing
            MessageBox.Show("Ya se está ejecutando Caronte", "Atención")
            End
        End If

        Me.Text = Trim(Me.CompanyName) & " - " & Me.ProductName & " - Ver. " & Me.ProductVersion
        Timer1.Interval = 30000
        Timer1.Start()

        limpiarDatos()
        CargarData()

    End Sub

    Private Sub limpiarDatos()

        bt_EnviarCorreos.Enabled = True
        lbl_Paciente.Text = String.Empty
        limpiarDatoseMail()

    End Sub

    Private Sub limpiarDatoseMail()

        s_paciente = String.Empty
        s_paciente = String.Empty
        s_paciente = String.Empty
        s_paciente = String.Empty
        s_Eps = String.Empty
        s_ingreso = String.Empty
        s_eMail = String.Empty
        s_eMailEps1 = String.Empty
        s_eMailEps2 = String.Empty
        s_identificacion = String.Empty
        s_historia = String.Empty
        s_servicio = String.Empty
        s_epstid = String.Empty
        s_responsable = String.Empty

    End Sub
    Private Sub CargarData()

        CargarDatos()

    End Sub

    Private Sub CargarDatos()

        Dim ds As DataSet

        ds = New DataSet
        sds = String.Empty
        AppProxy = New wsCaronte.IwsCaronteClient
        Compresion = New AppCompresion.AppCompresion

        Try
            sds = AppProxy.get_pacientes_data
        Catch ex As Exception
            sds = String.Empty
        Finally
            'AppProxy.Close()
        End Try

        If sds <> String.Empty Then
            Try
                ds = Compresion.DesomprimirDataset(sds)
            Catch ex As Exception
                sds = String.Empty
            Finally
            End Try
        End If

        If sds <> String.Empty Then
            dgv_Lista.DataSource = Nothing
            dgv_Lista.DataSource = ds.Tables(0)
        End If

    End Sub

    Private Sub OrdenaDatagrid()

        Dim dgcCol As DataGridViewColumn

        'Ordena datagrid
        dgcCol = dgv_Lista.Columns().Item("eMail")
        dgv_Lista.Sort(dgcCol, System.ComponentModel.ListSortDirection.Descending)
        dgv_Lista.Refresh()

    End Sub

    Private Function mensaje_enviar(mensaje_in As dtSMTPMessage) As Boolean

        Dim retorno As Boolean
        Dim s_emailt As String
        Dim s_generado As String
        Dim s_subject As String
        Dim s_emailTemp As String
        Dim s_ident As String
        Dim sc_eps As String
        Dim b_continuar As Boolean
        Dim b_enviar As Boolean
        Dim b_siguiente As Boolean
        Dim b_flag As Boolean
        Dim mensaje As MailMessage
        Dim m_body As StringBuilder
        'Dim m_adjunto As Attachment
        Dim nRow As Integer
        Dim n_index As Integer
        Dim n_registros As Integer

        mensaje = New MailMessage
        m_body = New StringBuilder

        retorno = False
        b_continuar = False
        b_flag = False
        b_enviar = False
        b_siguiente = True
        sc_eps = String.Empty
        s_emailTemp = String.Empty
        n_registros = 0
        nRow = -1

        'Ordena datagrid por EPS
        OrdenaDatagrid()

        'inicializa sc_eps
        sc_eps = Trim(dgv_Lista("EPS", 0).Value)
        d_Fecha = Now()

        While (b_siguiente = True)

            nRow += 1
            b_continuar = False
            b_enviar = False

            If (nRow <= dgv_Lista.Rows().Count - 1) Then

                If (Trim(dgv_Lista("EPS", nRow).Value <> "")) Then    'Archivo

                    s_Eps = Trim(dgv_Lista("EPS", nRow).Value)

                    If (sc_eps = s_Eps) Then

                        b_continuar = True
                        b_enviar = False

                    Else

                        b_continuar = False
                        b_enviar = True

                    End If

                Else

                    b_continuar = False

                End If


            Else

                If (b_flag = True) Then

                    b_enviar = True
                    b_continuar = False

                Else

                    b_enviar = False
                    b_continuar = False
                    b_siguiente = False

                End If

            End If


            If (b_continuar = True) Then

                b_flag = True
                s_eMail = Trim(dgv_Lista("eMail", nRow).Value)
                s_emailTemp = s_eMail

                'Control creción correo
                s_paciente = Trim(dgv_Lista("Nombre1", nRow).Value)
                s_paciente += " " & (dgv_Lista("Nombre2", nRow).Value)
                s_paciente += " " & Trim(dgv_Lista("Apellido1", nRow).Value)
                s_paciente += " " & (dgv_Lista("Apellido2", nRow).Value)
                s_paciente = ConfigurationManager.AppSettings("body_line_paciente") & s_paciente
                s_ingreso = Trim(dgv_Lista("Ingreso", nRow).Value)
                s_ingreso = ConfigurationManager.AppSettings("body_line_fecha") & s_ingreso
                s_eMail = dgv_Lista("eMail", nRow).Value

                If (s_eMail = String.Empty) Then
                    s_eMail = ConfigurationManager.AppSettings("email_dest0")
                End If

                s_identificacion = Trim(dgv_Lista("Identificacion", nRow).Value)
                s_historia = "Historia: " & Trim(dgv_Lista("Historia", nRow).Value)
                s_servicio = "Servicio de ingreso: " & Trim(dgv_Lista("Servicio", nRow).Value)
                s_responsable = "Resposable: " & Trim(dgv_Lista("Responsable", nRow).Value)
                s_epstid = Trim(dgv_Lista("Tid", nRow).Value)
                s_ident = "Identificación: " & s_epstid & " " & s_identificacion
                s_adjunto = Trim(dgv_Lista("Archivo", nRow).Value)

                m_body.AppendFormat("").AppendLine()
                m_body.AppendFormat(ConfigurationManager.AppSettings("body_Line1")).AppendLine()
                m_body.AppendFormat("").AppendLine()
                m_body.AppendFormat(s_paciente).AppendLine()
                m_body.AppendFormat("").AppendLine()
                m_body.AppendFormat(s_ident).AppendLine()
                m_body.AppendFormat("").AppendLine()
                m_body.AppendFormat(s_servicio).AppendLine()
                m_body.AppendFormat("").AppendLine()
                m_body.AppendFormat(s_ingreso).AppendLine()
                m_body.AppendFormat("").AppendLine()
                m_body.AppendFormat(s_responsable).AppendLine()
                m_body.AppendFormat("").AppendLine()
                m_body.AppendFormat("").AppendLine()

                'm_adjunto = New Attachment(s_adjunto)
                'mensaje.Attachments.Add(m_adjunto)

            Else

                If ((b_enviar = True) And (b_flag = True)) Then
                    s_generado = String.Empty
                    s_subject = String.Empty

                    lbl_Paciente.Text = "Enviando notificación a " & s_Eps
                    'inicializa cadenas estándar
                    s_generado = ConfigurationManager.AppSettings("Header_footer_generado") & " - " & d_Fecha.ToString
                    s_emailt = ConfigurationManager.AppSettings("email_dest0")
                    s_subject = ConfigurationManager.AppSettings("subject_individual") & " " & sc_eps

                    If (s_emailTemp.Contains(";")) Then
                        n_index = s_emailTemp.IndexOf(";")
                        s_eMailEps1 = s_emailTemp.Substring(1, n_index - 1)
                        s_eMailEps2 = s_emailTemp.Substring(n_index + 1)
                    Else
                        s_eMailEps1 = Trim(s_emailTemp)
                        's_eMailEps1 = "sistemas@clinicadelamujer.com.co"
                    End If

                    mensaje.To.Add(New MailAddress(s_eMailEps1))

                    If (s_eMailEps2 <> String.Empty) Then
                        mensaje.To.Add(New MailAddress(s_eMailEps2))
                    End If

                    mensaje.Subject = s_subject
                    'mensaje.CC.Add(New MailAddress(s_emailt))
                    mensaje.CC.Add(New MailAddress(ConfigurationManager.AppSettings("email_admisiones")))
                    mensaje.From = New MailAddress(ConfigurationManager.AppSettings("from_email"))

                    m_body.AppendFormat("").AppendLine()
                    m_body.AppendFormat("").AppendLine()
                    m_body.AppendFormat(ConfigurationManager.AppSettings("Header_footer1")).AppendLine()
                    m_body.AppendFormat("").AppendLine()
                    m_body.AppendFormat("").AppendLine()
                    m_body.AppendFormat(ConfigurationManager.AppSettings("Header_footer2")).AppendLine()
                    m_body.AppendFormat(ConfigurationManager.AppSettings("email_admisiones")).AppendLine()
                    m_body.AppendFormat(ConfigurationManager.AppSettings("Header_footer3")).AppendLine()
                    m_body.AppendFormat("").AppendLine()
                    m_body.AppendFormat("").AppendLine()
                    m_body.AppendFormat("").AppendLine()
                    m_body.AppendFormat(s_generado).AppendLine()
                    m_body.AppendFormat("").AppendLine()

                    mensaje.Body = m_body.ToString

                    Try
                        retorno = SmtpMail_send(mensaje)
                    Catch ex As Exception
                        AppGen.RegistreEvento("Error Servicio: mensaje_enviar - " & ex.Message, AppGeneral.TipoEvento.Ev_General, "Application")
                    Finally
                    End Try

                    limpiarDatoseMail()
                    m_body = New StringBuilder
                    mensaje = New MailMessage

                    If (nRow <= dgv_Lista.Rows().Count - 1) Then

                        s_Eps = Trim(dgv_Lista("EPS", nRow).Value)

                    End If

                    nRow -= 1
                    b_flag = False

                End If

            End If

            sc_eps = s_Eps

        End While

        lbl_Paciente.Text = String.Empty
        Return retorno

    End Function


    '------------------------------
    '-- Private

    Private Function SmtpMail_send(mensaje As MailMessage) As Boolean

        Dim retorno As Boolean
        Dim credentials As NetworkCredential

        retorno = False
        SmtpServidor = New SmtpClient

        credentials = New NetworkCredential(ConfigurationManager.AppSettings("smtp_user"), ConfigurationManager.AppSettings("smtp_password"))
        SmtpServidor.Host = ConfigurationManager.AppSettings("smtp_host")
        SmtpServidor.Port = ConfigurationManager.AppSettings("smtp_port")
        SmtpServidor.Credentials = credentials
        SmtpServidor.EnableSsl = True

        Try
            SmtpServidor.Send(mensaje)
            retorno = True
        Catch ex As Exception
            AppGen.RegistreEvento("Error Servicio: SmtpMail_send - " & ex.Message, AppGeneral.TipoEvento.Ev_General, "Application")
        Finally
            SmtpServidor.Dispose()
        End Try

        Return retorno

    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        CargarDatos()

    End Sub

    Private Sub bt_EnviarCorreos_Click(sender As Object, e As EventArgs) Handles bt_EnviarCorreos.Click

        enviarCorreo()
        limpiarDatos()
        actualiza_envio()

        'Reinicia timer
        Timer1.Start()

    End Sub

    Private Sub dgv_Lista_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Lista.RowHeaderMouseClick

        Dim nRow As Integer
        Dim s_emailTemp As String
        Dim colRow As DataGridViewSelectedRowCollection
        Dim n_index As Integer

        n_index = 0
        s_emailTemp = String.Empty
        'bt_AdjuntaArchivo.Enabled = True
        colRow = dgv_Lista.SelectedRows

        nRow = dgv_Lista.CurrentRow.Index
        nFila = nRow
        s_paciente = Trim(dgv_Lista("Nombre1", nRow).Value)
        s_paciente += " " & Trim(dgv_Lista("Nombre2", nRow).Value)
        s_paciente += " " & Trim(dgv_Lista("Apellido1", nRow).Value)
        s_paciente += " " & Trim(dgv_Lista("Apellido2", nRow).Value)
        s_Eps = Trim(dgv_Lista("EPS", nRow).Value)
        s_ingreso = Trim(dgv_Lista(17, nRow).Value)
        s_eMail = Trim(dgv_Lista("eMail", nRow).Value)
        s_emailTemp = Trim(dgv_Lista("eMailEps", nRow).Value)
        s_identificacion = Trim(dgv_Lista("Identificacion", nRow).Value)
        s_historia = Trim(dgv_Lista("Historia", nRow).Value)
        s_servicio = Trim(dgv_Lista("Servicio", nRow).Value)
        s_responsable = Trim(dgv_Lista("Responsable", nRow).Value)
        s_epstid = Trim(dgv_Lista("Tid", nRow).Value)
        lbl_Paciente.Text = s_paciente & " - " & s_identificacion & " - Servicio: " & s_servicio

        If (s_emailTemp.Contains(";")) Then
            n_index = s_emailTemp.IndexOf(";")
            s_eMailEps1 = s_emailTemp.Substring(1, n_index - 1)
            s_eMailEps2 = s_emailTemp.Substring(n_index + 1)
        Else
            s_eMailEps1 = Trim(s_emailTemp)
        End If

    End Sub

    Private Sub enviarCorreo()

        Dim msg As dtSMTPMessage
        Dim m_body As StringBuilder
        Dim enviado As Boolean

        m_body = New StringBuilder
        msg = New dtSMTPMessage
        enviado = False

        msg.body = m_body.ToString

        enviado = mensaje_enviar(msg)

    End Sub

    Private Sub actualiza_envio()

        For nRow = 0 To dgv_Lista.Rows.Count - 1

            AppProxy = New wsCaronte.IwsCaronteClient

            If (Trim(dgv_Lista("EPS", nRow).Value <> "")) Then

                s_identificacion = Trim(dgv_Lista("Identificacion", nRow).Value)
                s_epstid = Trim(dgv_Lista("Tid", nRow).Value)

                Try
                    AppProxy.set_paciente_enviado(s_identificacion, s_epstid, "Caronte")
                Catch ex As Exception
                    AppGen.RegistreEvento("Error Servicio: actualiza_envio - " & ex.Message, AppGeneral.TipoEvento.Ev_General, "Application")
                Finally
                    AppProxy.Close()
                End Try

            End If

        Next

    End Sub

End Class
