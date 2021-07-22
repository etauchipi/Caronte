Module ModuleMain

    'Control general
    Public b_cambio As Boolean

    'Mensajes
    Public s_paciente As String
    Public s_identificacion As String
    Public s_epstid As String
    Public s_adjunto As String
    Public s_Eps As String
    Public s_eMail As String
    Public s_eMailEps1 As String
    Public s_eMailEps2 As String
    Public s_historia As String
    Public s_ingreso As String
    Public s_servicio As String
    Public s_responsable As String
    Public sds As String
    Public b_Enviado As Boolean
    Public nFila As Integer

    'control 
    Public d_Fecha As Date

    'data
    Public sCnn As String
    Public cConn As String

    Public Class dtSMTPMailServer
        Public Property smtp_Host As String
        Public Property smtp_User As String
        Public Property smtp_Password As String
        Public Property smtp_Port As String
    End Class

    Public Class dtSMTPMessage
        Public Property id_usuario As Integer
        Public Property user As String
        Public Property codigo As String
        Public Property nombre As String
        Public Property area As String
        Public Property ubicacion As String
        Public Property identificacion_tipo As String
        Public Property identificacion As String
        Public Property email As String

        '-----------
        ' Mensaje

        Public Property email2 As String
        Public Property email3 As String
        Public Property email_rh As String
        Public Property desde As String
        Public Property hasta As String
        Public Property subject As String
        Public Property body As String
        Public Property header As String
        Public Property footer As String

    End Class

    Public Class eMailData
        Public Property Empleado_Nombre As String
        Public Property Empleado_eMail As String
        Public Property Subject As String
        Public Property Body As String
        Public Property Footer As String
        Public Property Adicional_eMail1 As String
        Public Property Adicional_eMail2 As String
    End Class

End Module