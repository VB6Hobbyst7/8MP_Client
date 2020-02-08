Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization

<Runtime.InteropServices.ComVisible(True)>
Public Class clsAPIService
    Private vUrl As String
    Private vAccessToken As String

    Public Property Url() As String
        Get
            Return vUrl
        End Get
        Set(ByVal Value As String)
            Me.vUrl = Value
        End Set
    End Property

    Public Property access_token() As String
        Get
            Return vAccessToken
        End Get
        Set(ByVal Value As String)
            Me.vAccessToken = Value
        End Set
    End Property


    Private Function PostJSON(ByVal JsonData As String, address As String,
                              Optional method As String = "POST") As HttpWebRequest
        Dim objhttpWebRequest As HttpWebRequest
        Try

            Dim request As WebRequest = WebRequest.Create(address)
            request.Method = method
            request.PreAuthenticate = True
            request.Headers.Add("Authorization", "Bearer " + vAccessToken)

            Dim httpWebRequest = DirectCast(request, HttpWebRequest)
            httpWebRequest.ContentType = "application/json"
            httpWebRequest.Method = method

            Dim postBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(JsonData)
            request.ContentLength = postBytes.Length
            Dim stream As Stream = request.GetRequestStream()
            stream.Write(postBytes, 0, postBytes.Length)
            stream.Close()

            'Using streamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
            '    streamWriter.Write(JsonData)
            '    streamWriter.Flush()
            '    streamWriter.Close()
            'End Using

            objhttpWebRequest = httpWebRequest
            Return objhttpWebRequest
            'Dim myHttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            'Dim myWebSource As New StreamReader(myHttpWebResponse.GetResponseStream())
            'Dim myPageSource As String = myWebSource.ReadToEnd()

            'Dim jss = New JavaScriptSerializer()
            'Dim data As Object = jss.Deserialize(Of Object)(myPageSource)
            'Return data

        Catch ex As Exception
            MsgBox("Send Request Error[{0}]", ex.Message)

            Return Nothing
        End Try

        Return objhttpWebRequest

    End Function

    Private Function GetResponse(ByVal httpWebRequest As HttpWebRequest) As String
        Dim strResponse As String = "Bad Request:400"
        Try
            Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()

                strResponse = result.ToString()
            End Using
        Catch ex As Exception
            Console.WriteLine("GetResponse Error[{0}]", ex.Message)

            Return ex.Message
        End Try

        Return strResponse

    End Function

    Public Function SendRequest(ByVal address As String, jsonData As String,
                                 Optional contentType As String = "application/json",
                                 Optional method As String = "POST") As Object

        'Dim JsonData As String = "{""type"":""Point"",""coordinates"":[-105.01628,39.57422]}"
        Dim myRequest As HttpWebRequest = PostJSON(jsonData, address, method)
        Dim jss = New JavaScriptSerializer()
        Dim data As Object = jss.Deserialize(Of Object)(GetResponse(myRequest))
        Return data
    End Function

    Public Function getJsonObject(ByVal address As String) As Object
        Try
            'Support request with Token
            Dim request As WebRequest = WebRequest.Create(address)
            request.Method = "GET"
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes("")
            request.PreAuthenticate = True
            request.Headers.Add("Authorization", "Bearer " + vAccessToken)

            Dim myHttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim myWebSource As New StreamReader(myHttpWebResponse.GetResponseStream())
            Dim myPageSource As String = myWebSource.ReadToEnd()

            Dim jss = New JavaScriptSerializer()
            Dim data As Object = jss.Deserialize(Of Object)(myPageSource)
            Return data
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function getJsonString(ByVal address As String) As String
        'Support request with Token
        Dim request As WebRequest = WebRequest.Create(address)
        request.Method = "GET"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes("")
        request.PreAuthenticate = True
        request.Headers.Add("Authorization", "Bearer " + vAccessToken)

        Dim myHttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        Dim myWebSource As New StreamReader(myHttpWebResponse.GetResponseStream())
        Dim myPageSource As String = myWebSource.ReadToEnd()
        Return myPageSource
    End Function

    Public Function getObjectByUrl(vUrl As String) As Object
        Dim json As Object
        json = getJsonObject(vUrl)
        getObjectByUrl = json
    End Function

    Public Function getJsonByUrl(vUrl As String) As String
        Dim json As Object
        json = getJsonString(vUrl)
        getJsonByUrl = json
    End Function

    Public Function getObjectBySlug(vApp As String, vSlug As String) As Object
        Dim json As Object
        Dim vUrlSlug As String
        vUrlSlug = vUrl + "/api/" + vApp + "/" + vSlug & "/"
        json = getJsonObject(vUrlSlug)
        getObjectBySlug = json
    End Function

    Public Function getJsonBySlug(vApp As String, vSlug As String) As String
        Dim json As Object
        Dim vUrlSlug As String
        vUrlSlug = vUrl + "/api/" + vApp + "/" + vSlug & "/"
        json = getJsonString(vUrlSlug)
        Return json
    End Function


    Public Function getRoutingDetail(vRoute As String, vOperation As String) As Object
        'VRoute = Routing name
        'vOperation = Operation name
        Dim json As Object
        'comment on Jan 1,2020
        'json = getJsonObject(vUrl + "/api/routing-detail/?routing=" + vRoute + "&operation=" & vOperation & "&status=A")
        json = getJsonObject(vUrl + "/api/routing-detail/?routing=" + vRoute + "&operation=" & vOperation & "&status=A")
        Return json
    End Function
End Class
