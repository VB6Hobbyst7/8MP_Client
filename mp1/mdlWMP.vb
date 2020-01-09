Module mdlWMP
    'Public Root_url As String = "http://127.0.0.1:8000"
    'Public Cache_url As String = "http://127.0.0.1:5000"

    'Public Root_url As String = "http://192.168.99.100:8000"
    'Public Cache_url As String = "http://192.168.99.100:8001"

    Public Root_url As String '= "http://192.168.1.117:8000"
    Public Cache_url As String '= "http://192.168.1.117:8001"

    Public login_user As String
    Public login_password As String

    'Token variable
    Public access_token As String
    Public refresh_token As String
    Public user_id As String
    Public exp_token As Date

End Module
