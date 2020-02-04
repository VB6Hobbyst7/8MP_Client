Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Dynamic
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

<Runtime.InteropServices.ComVisible(True)>
Public Class frmAssembly

    Dim objApiService As New clsAPIService
    Dim objSerialNumber As clsSerialNumber


    '---GLOBAL Parameter--
    Dim gHostName As String
    Dim gProductRegExp As String
    Dim gCurrentRoute As String
    Dim gCurrentRouteSlug As String
    Dim gCurrentRouteUrl As String
    Dim gCurrentRouteDetailUrl As String
    Dim gCurrentRouteDetailSlug As String
    Dim gCurrentRoutePosition As String

    Dim gNextPass As String
    Dim gNextFail As String
    Dim gNextTitle As String

    Dim gCurrentRegExp As String

    Dim gOperationName As String
    Dim gOperationSlug As String
    Dim gOperationType As String

    Dim gProductname As String
    Dim gProductSlug As String

    Dim gWorkOrdername As String
    Dim gWorkOrderSlug As String

    Dim gSerialNumber As Object
    Dim gSerialNumberSlug As String

    Private operationPropertyValue As String
    Public Property operation() As String
        Get
            Return operationPropertyValue
        End Get
        Set(ByVal value As String)
            operationPropertyValue = value
        End Set
    End Property



    'Using Function()
    Public Shared Function getJsonString(ByVal address As String) As String

        Dim client As WebClient = New WebClient()
        Dim reply As String = client.DownloadString(address)
        Return reply
    End Function

    'Public Shared Function getJsonObject3(ByVal address As String) As Object
    '    Dim client As WebClient = New WebClient()
    '    Dim json As String = client.DownloadString(address)
    '    Dim jss = New JavaScriptSerializer()
    '    Dim data As Object = jss.Deserialize(Of Object)(json)
    '    Return data
    'End Function

    'Public Shared Function getJsonObject(ByVal address As String) As Object
    '    'Support request with Token
    '    Dim request As WebRequest = WebRequest.Create(address)
    '    request.Method = "GET"
    '    Dim byteArray As Byte() = Encoding.UTF8.GetBytes("")
    '    request.PreAuthenticate = True
    '    request.Headers.Add("Authorization", "Bearer " + access_token)


    '    Dim myHttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
    '    Dim myWebSource As New StreamReader(myHttpWebResponse.GetResponseStream())
    '    Dim myPageSource As String = myWebSource.ReadToEnd()

    '    Dim jss = New JavaScriptSerializer()
    '    Dim data As Object = jss.Deserialize(Of Object)(myPageSource)
    '    Return data


    'End Function

    Private Function getSerialNumber(vSerialNumber As String, Optional workorder As String = "") As Object
        Dim json As Object
        If workorder <> "" Then
            json = objApiService.getJsonObject(vUrl + "/api/serialnumber/?number=" + vSerialNumber +
                                           "&workorder=" + workorder)
        Else
            json = objApiService.getJsonObject(vUrl + "/api/serialnumber/?number=" + vSerialNumber)
        End If
        getSerialNumber = json
    End Function


    'Private Function getObjectByUrl(vUrl As String) As Object
    '    Dim json As Object
    '    json = getJsonObject(vUrl)
    '    getObjectByUrl = json
    'End Function

    'Private Function getObjectBySlug(vApp As String, vSlug As String) As Object
    '    Dim json As Object
    '    Dim vUrlSlug As String
    '    vUrlSlug = vUrl + "/api/" + vApp + "/" + vSlug & "/"
    '    json = getJsonObject(vUrlSlug)
    '    getObjectBySlug = json
    'End Function

    'Private Function getRoutingDetail(vRoute As String, vOperation As String) As Object
    '    'VRoute = Routing name
    '    'vOperation = Operation name
    '    Dim json As Object
    '    json = getJsonObject(vUrl + "/api/routing-detail/?route=" + vRoute + "&operation=" & vOperation)
    '    Return json
    'End Function

    ''End used Function

    'Private Function getParameterBySlug(vRoutingDetailSlug As String) As Object
    '    Dim json As Object
    '    json = getJsonObject(vUrl + "/api/routingdetail/" + vRoutingDetailSlug)
    '    getParameterBySlug = json
    'End Function

    'Private Function getItemBySlug(vParameterSlug As String) As Object
    '    Dim json As Object
    '    json = getJsonObject(vUrl + "/api/parameter/" + vParameterSlug)
    '    getItemBySlug = json
    'End Function



    'Private Function getRouting(vRouteSlug As String) As Object
    '    Dim json As Object
    '    json = getJsonObject(vUrl + "/api/routing/" + vRouteSlug)
    '    getRouting = json
    'End Function



    'Private Function getRoutingDetail(vSlug As String) As Object
    '    Dim json As Object
    '    json = getJsonObject(vUrl + "/api/routingdetail/" & vSlug)
    '    getRoutingDetail = json
    'End Function

    'Private Function getSnippetBySlug(vSnippetSlug As String) As Object
    '    Dim json As Object
    '    json = getJsonObject(vUrl + "/api/snippet/" + vSnippetSlug)
    '    Return json
    'End Function

    'Private Function getWorkOrder(vWorkOrderSlug As String) As Object
    '    Dim json As Object
    '    json = getJsonObject(vUrl + "/api/workorder/" + vWorkOrderSlug + "/")
    '    getWorkOrder = json
    'End Function

    'Private Function getProduct(vProductSlug As String) As Object
    '    Dim json As Object
    '    json = getJsonObject(vUrl + "/api/product/" + vProductSlug + "/")
    '    getProduct = json
    'End Function
    'Private Function getSnippetBySlug(vSnippetSlug As String) As Object
    '    Dim json As Object
    '    json = getJsonObject(vUrl + "/api/snippet/" + vSnippetSlug)
    '    Return json
    'End Function

    Private vUrl As String = Root_url
    Private vCacheUrl As String = Cache_url
    Private vCurrentRoutingDetailSlug As String
    Private vCurrentRoutingDetailUrl As String
    Private vDefaultNextPassOperation As String
    Private vDefaultNextFailOperation As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If txtSn.Text = "" Then
            MsgBox("Unit serial number is require", MsgBoxStyle.Critical, "No serial number")
            Exit Sub
        End If





        gSerialNumber = Nothing
        Dim vSerialNumber As String = txtSn.Text
        'Initial value of Serial number
        objSerialNumber = New clsSerialNumber()
        With objSerialNumber
            'Mandatory Parameter
            .url = vUrl
            .access_token = access_token
            '--------------------
            .serialnumber = vSerialNumber

            .Form = Me
        End With
        'End initial
        Dim objSn As Object
        objSn = objSerialNumber.getObject()




        'gOperationType
        Dim vSelectedOpr As String = gOperationName  'cbOperation.SelectedValue
        Dim vSelectedWorkOrder As String = gWorkOrderSlug  ' cbWorkOrder.SelectedValue
        If gOperationType <> "REGISTRATION" Then
            '-----Not Registration--
            If objSn Is Nothing Then
                MsgBox(vSerialNumber & " does not exist in system or not in WIP",
                       MsgBoxStyle.Critical, "Not found unit serial number")
                txtSn.Select(0, txtSn.TextLength)
                Exit Sub
            End If

            gSerialNumber = objSn

            Dim vWorkOrder As String = objSn("workorder")

            If Not checkRouting(vSerialNumber, vWorkOrder, gOperationName) Then
                txtSn.Select(0, txtSn.TextLength)
                Exit Sub
            End If

            '--Hook --PRE
            If Not executeHook("PRE", btnStart.Name) Then
                Exit Sub
            End If
            '------------



            '---Check perform---
            If objSn("perform_resource") <> "" Then
                If objSn("perform_resource") <> gHostName Then
                    MsgBox(vSerialNumber & " is performing on " & objSn("perform_resource"),
                       MsgBoxStyle.Critical, "On performing")
                    txtSn.Select(0, txtSn.TextLength)
                    Exit Sub
                End If
            Else
                '---Stamp Perform
                setPerformSerialNumber(True, vSelectedOpr)
            End If
            '-------------------

            btnCancel.Enabled = True
            btnStart.Enabled = False
            txtSn.Enabled = False
            btnPass.Enabled = True
            btnFail.Enabled = True

            'Parameter
            'CreateObject(gCurrentRouteDetailUrl)
            With UcAssembly
                .url = vUrl
                .cache_url = vCacheUrl
                .access_token = access_token
                .routing = gCurrentRouteDetailUrl
            End With

        End If




        '--Hook --POST
        If Not executeHook("POST", btnStart.Name) Then
            Exit Sub
        End If



        'vCurrentRoutingDetailSlug = objSerialNumber.object_RoutingDetail("slug")

        'CreateObject(vCurrentRoutingDetailSlug)

        'btnStart.Enabled = False
        'btnRefresh.Enabled = True
        'txtSn.Enabled = False

        'btnPass.Enabled = True
        'btnFail.Enabled = True




        'If Not checkSerialNumber(txtSn.Text) Then
        '    txtSn.Select(0, txtSn.Text.Length)
        '    txtSn.Select()
        'Else
        '    CreateObject(vCurrentRoutingDetailSlug)
        '    btnStart.Enabled = False
        '    btnRefresh.Enabled = True
        '    txtSn.Enabled = False

        '    btnPass.Enabled = True
        '    btnFail.Enabled = True
        'End If

    End Sub

    Function registerSerialNUmber(vSn As String, vWorkOrder As String,
                                  vOperation As String, vRouting As String,
                                  Optional vNote As String = "") As Boolean
        'Check QTY 
        'vWorkOrder -->ID


        'get Routing Detail, Next Pass and Next Fail
        Dim objRouteDetail As Object
        objRouteDetail = objApiService.getRoutingDetail(vRouting, vOperation)
        Dim vNextPass As String = ""
        Dim vNexFail As String = ""
        If objRouteDetail("results").length = 0 Then
            MsgBox("Not found Next Pass configuration of routing " & vRouting, MsgBoxStyle.Critical,
                   "Not found Next pass info")
            Return False
        Else
            vNextPass = objRouteDetail("results")(0)("next_pass")
            vNexFail = objRouteDetail("results")(0)("next_fail")
        End If

        ' Dim objLastOperation As Object = objApiService.getObjectBySlug("operation", vOperation)

        Dim json As New clsSerialNumberJson
        With json
            .number = vSn
            .workorder = vWorkOrder
            .routing = vRouting
            .description = vNote
            .last_result = True
            .last_operation = vOperation 'objLastOperation("name") 'must be name
            .current_operation = vNextPass
            .wip = True
            .status = "A"
            .unit_type = "BUILT"
            .user = user_id
        End With
        Dim output As String
        output = JsonConvert.SerializeObject(json)

        Dim objResponse As Object
        objResponse = objApiService.SendRequest(vUrl & "/api/serialnumber/", output)
        gSerialNumberSlug = objResponse("slug")
        tssSn.Text = vSn & " move to " & vNextPass
        '----Performing---
        Dim vSnMasterId As Integer
        vSnMasterId = objResponse("id")
        Dim performing As New clsPerformingJson
        With performing
            .sn = vSnMasterId
            .operation = vOperation ' objLastOperation("name")
            .result = True
            .interval = 1
            .resource_name = gHostName
            .remark = vNote
            .start_time = Now
            .stop_time = Now
            .user = user_id
        End With
        output = JsonConvert.SerializeObject(performing)
        objResponse = objApiService.SendRequest(vUrl & "/api/performing/", output)
        Dim x As String
        x = objResponse("uid")

        '-----------------------
        Return True
    End Function

    Function checkRouting(vSn As String, vWorkorder As String, vOperation As String) As Boolean
        Dim objSns As Object
        objSns = getSerialNumber(vSn, vWorkorder)

        Dim vSnSlug As String = ""
        Dim vSnUrl As String = ""
        Dim vWip As Boolean = False
        Dim vSerialNumber As String = ""

        Dim objRoute As Object = Nothing
        Dim vRoute As String = ""

        Dim objSn As Object = Nothing
        For Each objSn In objSns("results")
            vSerialNumber = objSn("number")
            'objWorkOrder = objSn("workorder")
            vSnSlug = objSn("slug")
            vWip = objSn("wip")
            'objRoute = objSn("routing")
            'Looking for Record that WIP == True
            If vWip Then
                'vWorkOrder = objWorkOrder("name")
                vSnUrl = objSn("url")
                Exit For
            End If
        Next

        If Not vWip Then
            MsgBox("Serial number " & vSn & " is not in WIP",
            MsgBoxStyle.Critical, "Not in WIP")
            Exit Function
        End If

        'Get Serial number details for particular SN
        objSn = objApiService.getObjectByUrl(vSnUrl)

        'Get Routing for Serial number
        Dim objRouting As Object = Nothing
        objRouting = getSerialNumberRouteObject(vSn, vSnUrl)
        If IsNothing(objRouting) Then
            Exit Function
        End If

        'Start Check Routing process
        Dim vCurrentOpr As String
        Dim vSelectedOpr As String
        '1)Check if SN.curr == Selected.operation
        vCurrentOpr = objSn("current_operation")

        'Dim objOperation As Object = objApiService.getObjectBySlug("operation", vOperation)
        vSelectedOpr = vOperation


        'Get Routing Details (Route + Operation)
        Dim objRouteDetail As Object

        gCurrentRoute = objRouting("name")
        gCurrentRouteUrl = objRouting("url")

        objRouteDetail = objApiService.getRoutingDetail(objRouting("name"), vSelectedOpr)
        If objRouteDetail("results").length = 0 Then
            MsgBox("Operation :" & vSelectedOpr & " is not exist in routing :" & objRouting("name"),
                   MsgBoxStyle.Critical, "Operation not exist.")
            Exit Function
        Else
            'Final Route Detail Slug
            'vCurrentRoutingDetailSlug = objRouteDetail("results")(0)("slug")
            vCurrentRoutingDetailUrl = objRouteDetail("results")(0)("url")
        End If

        'Get Routing Detail
        objRouteDetail = objApiService.getObjectByUrl(vCurrentRoutingDetailUrl)

        gNextPass = objRouteDetail("next_pass")
        gNextFail = objRouteDetail("next_fail")

        'In case No Next Pass configured , system will send back to previous operaion.
        If gNextPass = "" Then
            gNextPass = gSerialNumber("last_operation")
            lblNextPass.Text = gNextPass & "(Previous)"
        Else
            lblNextPass.Text = gNextPass
        End If

        gCurrentRouteDetailUrl = objRouteDetail("url")
        gCurrentRouteDetailSlug = objRouteDetail("slug")
        gCurrentRoutePosition = objRouteDetail("position")

        'Show Routing ,next pass and next fail
        lblRouting.Text = objRouting("name")
        'lblNextPass.Text = gNextPass
        lblnextFail.Text = gNextFail

        If gCurrentRoutePosition = "L" Then
            lblNextPass.Text = lblNextPass.Text & " -->END Process"
        End If

        Dim vRoutingErrorMsg As String = ""
        If vCurrentOpr = vSelectedOpr Then
            'In case Sn.curr.Operation = Selected.Operation  -- check only Reject Routing
            If objRouteDetail("reject_code").length = 0 Then
                'Operation Matched and No Reject condition.
                Return True
            Else
                'Check Reject Code
                If checkExceptance(objRouteDetail("reject_code")) Then
                    'exit return False
                    vRoutingErrorMsg = "Correct routing !!! " & vbCrLf &
                                    "But reject routing result is FAILED"
                    MsgBox(vRoutingErrorMsg,
                                MsgBoxStyle.Critical, "Reject check")
                    Exit Function
                End If
            End If
        Else
            'In case Sn.curr.Operation <> Selected.Operation  -- check only Accept Routing
            If objRouteDetail("accept_code").length = 0 Then
                'Operation Matched and No Reject condition.
                vRoutingErrorMsg = "Wrong routing !!! Unit must perform at :" & vCurrentOpr & vbCrLf &
                                    "and No Acceptance routing configured"
                MsgBox(vRoutingErrorMsg,
                            MsgBoxStyle.Critical, "No Accept to perform")
                Return False
            Else
                'Check Accept Code
                If Not checkAcceptance(objRouteDetail("accept_code")) Then
                    'exit return False
                    vRoutingErrorMsg = "Wrong routing !!! Unit must perform at :" & vCurrentOpr & vbCrLf &
                                    "and Acceptance routing result is FAILED"
                    MsgBox(vRoutingErrorMsg,
                            MsgBoxStyle.Critical, "Not Accept to perform")

                    Exit Function
                End If
            End If


        End If




        ''Check Current Operation-
        'Dim vCurrentOpr As String
        'Dim vObjRoutingDetail As Object
        'vObjRoutingDetail = getRoutingDetail(vCurrentRoutingDetailSlug)

        'If Not IsNothing(objSn("current_operation")) Then
        '    vCurrentOpr = objSn("current_operation")("name")
        'Else
        '    vCurrentOpr = objSn("current_operation")
        'End If

        ''get Next pass and Next Fail.
        'If Not IsNothing(vObjRoutingDetail("next_pass")) Then
        '    vDefaultNextPassOperation = vObjRoutingDetail("next_pass")("name")
        'End If
        'If Not IsNothing(vObjRoutingDetail("next_fail")) Then
        '    vDefaultNextFailOperation = vObjRoutingDetail("next_fail")("name")
        'End If
        ''-----------------------------







        'If everything is Okay ,it will return True
        Return True
    End Function

    Function checkAcceptance(vAcceptSlugLists As Object) As Boolean
        'ANY True -- return True
        Dim objAccept As Object
        Dim vAcceptSlug As String

        Dim vSnippetUrl As String = ""
        Dim vCode As String
        checkAcceptance = False
        For Each vAcceptSlug In vAcceptSlugLists
            objAccept = objApiService.getObjectByUrl(vAcceptSlug)

            vSnippetUrl = objAccept("snippet")("url")
            'objSnippet = getSnippetBySlug(vSnippetSlug)
            Dim objSnippet As Object = Nothing
            objSnippet = objApiService.getObjectByUrl(vSnippetUrl)
            vCode = objSnippet("code")
            'Execute Script-----
            If vCode <> "" And objAccept("status") = "A" Then
                If executeScript(vCode) Then
                    checkAcceptance = True
                    Exit For
                End If
            End If
            '-------------------
        Next
    End Function

    Function checkExceptance(vExceptObjs As Object) As Boolean
        'ANY True -- return True
        Dim objReject As Object
        Dim vRejectSlug As String

        Dim vSnippetUrl As String = ""
        Dim vCode As String
        checkExceptance = False
        For Each vRejectSlug In vExceptObjs
            objReject = objApiService.getObjectByUrl(vRejectSlug)

            vSnippetUrl = objReject("snippet")("url")
            Dim objSnippet As Object = Nothing
            objSnippet = objApiService.getObjectByUrl(vSnippetUrl)
            vCode = objSnippet("code")
            'Execute Script-----
            If vCode <> "" And objReject("status") = "A" Then
                If executeScript(vCode) Then
                    checkExceptance = True
                    Exit For
                End If
            End If
            '-------------------
        Next
    End Function

    Private Function executeScript(vCode As String) As Boolean
        Dim vCls As New clsMPFlex
        'initial
        vCls.Form = Me
        vCls.Url = vUrl
        vCls.cacheUrl = vCacheUrl

        Dim vReturn As Object
        vReturn = vCls.executeScritp(vCode)
        'MsgBox(vCls.Url)
        'lblSuccess.Text = vCls.success
        'lblMsg.Text = vCls.message
        If Not vCls.success Then
            MsgBox(vCls.error_message)
        End If

        Return vReturn
    End Function

    Function getSerialNumberRouteObject(vSn As String, vSnUrl As String) As Object
        Dim objSn As Object = Nothing
        Dim objRouting As Object = Nothing
        Dim objWorkOrder As Object = Nothing

        'Get Serial number details for specific SN (by Url)
        objSn = objApiService.getObjectByUrl(vSnUrl)

        'If there is routing defined ,Get Routing for Serial number
        If objSn("routing") <> "" Then
            objRouting = objApiService.getObjectBySlug("routing", objSn("routing"))
            Return objRouting
        End If

        'Get WorkOrder's Routing
        objWorkOrder = objApiService.getObjectBySlug("workorder", objSn("workorder"))
        If Not IsNothing(objWorkOrder("routing")) Then
            Return objWorkOrder("routing")
        End If


        'Check Product's Routing
        'Dim vProduct As String
        Dim objProduct As Object
        objProduct = objApiService.getObjectByUrl(objWorkOrder("product")("url"))
        'vtmpRoute = objProduct("routing")
        If Not IsNothing(objProduct("routing")) Then
            'Routing assigned
            Return objProduct("routing")
        End If
        MsgBox("Not found Routing setting for this serial number",
               MsgBoxStyle.Critical, "Not found routing setting")
        Return Nothing
Exit_Function:
        'Return Routing Detail
        'Return Nothing
    End Function

    Sub CreateObject(vRoutingDetailUrl As String)
        Dim objRoutingDetail As Object
        objRoutingDetail = objApiService.getObjectByUrl(vRoutingDetailUrl)

        'Dim tabControl As New TabControl

        'With tabControl
        '    .Name = "Parameter"
        '    .TabIndex = 3
        '    '.Parent = gbParameter
        '    ' .Location = New Point(gbParameter.Left + 5, gbParameter.Top + 5)
        '    .Location = New Point(10, txtComment.Top + txtComment.Height + 10)
        '    .Size = New Size(Me.Width - 20, 300)
        '    .SizeMode = TabSizeMode.Normal
        '    .AutoSize = True
        '    .Anchor = AnchorStyles.Left + AnchorStyles.Right
        '    ' .Dock = DockStyle.Fill
        'End With

        Dim objParam As Object
        Dim vParamSlug As String
        Dim pInitialPoint As Point
        Dim iParameterIndex As Integer = 0
        For Each vParamSlug In objRoutingDetail("parameter")
            pInitialPoint = New Point(5 + (380 * iParameterIndex), txtComment.Top + txtComment.Height + 10)
            '-----get Parameter Object----
            objParam = objApiService.getObjectByUrl(vParamSlug)
            If objParam("status") = "D" Then
                Continue For
            End If
            '-----------------------------
            'Dim tabPage As New TabPage
            'tabPage.Text = IIf(IsDBNull(objParam("title")), objParam("name"), objParam("title"))
            'tabPage.Name = objParam("name")
            'tabPage.AutoScroll = True
            'tabPage.AutoSize = True
            '' AddHandler Text.Validating, AddressOf text_Validating
            'tabControl.TabPages.Add(tabPage)
            ''------Add Parameter to Page---

            addParameterToPage(vParamSlug, pInitialPoint)
            iParameterIndex = iParameterIndex + 1
            ''------------------------------
        Next
        'tabControl.Show()
        'Me.Controls.Add(tabControl)
    End Sub

    'Sub CreateObject(vRoutingDetailUrl As String)
    '    Dim objRoutingDetail As Object
    '    objRoutingDetail = objApiService.getObjectByUrl(vRoutingDetailUrl)

    '    Dim tabControl As New TabControl
    '    'Dim tabPage As New TabPage
    '    With tabControl
    '        .Name = "Parameter"
    '        .TabIndex = 3
    '        '.Parent = gbParameter
    '        ' .Location = New Point(gbParameter.Left + 5, gbParameter.Top + 5)
    '        .Location = New Point(10, txtComment.Top + txtComment.Height + 10)
    '        .Size = New Size(Me.Width - 20, 300)
    '        .SizeMode = TabSizeMode.Normal
    '        .AutoSize = True
    '        .Anchor = AnchorStyles.Left + AnchorStyles.Right
    '        ' .Dock = DockStyle.Fill
    '    End With


    '    ' gbParameter.Controls.Add(tabControl)

    '    Dim objParam As Object
    '    Dim vParamSlug As String
    '    For Each vParamSlug In objRoutingDetail("parameter")
    '        '-----get Parameter Object----
    '        objParam = objApiService.getObjectByUrl(vParamSlug)
    '        If objParam("status") = "D" Then
    '            Continue For
    '        End If
    '        '-----------------------------
    '        Dim tabPage As New TabPage
    '        tabPage.Text = IIf(IsDBNull(objParam("title")), objParam("name"), objParam("title"))
    '        tabPage.Name = objParam("name")
    '        tabPage.AutoScroll = True
    '        tabPage.AutoSize = True
    '        ' AddHandler Text.Validating, AddressOf text_Validating
    '        tabControl.TabPages.Add(tabPage)
    '        ''------Add Parameter to Page---
    '        'vParamSlug = objParam("slug")
    '        addParameterToPage(vParamSlug, tabPage)
    '        ''------------------------------
    '    Next
    '    tabControl.Show()
    '    Me.Controls.Add(tabControl)
    'End Sub
    Sub addParameterToPage(vParameterSlug As String, iPoint As Point)
        Dim objItems As Object

        'objItems = getItemBySlug(vParameterSlug)
        objItems = objApiService.getObjectByUrl(vParameterSlug)

        Dim vId As String
        Dim vItemName As String
        Dim vTitle As String
        Dim vDefaultValue As String
        Dim vRegExp As String
        Dim vItemSlug As String
        Dim vItemType As String
        Dim vRequired As Boolean
        Dim vAbsoluteUrl As String

        Dim vPosBottom As Integer = 10
        Dim ucText As New ucParaText
        Dim ucList As New ucParamList
        Dim ucRadio As New ucParamRadio
        Dim ucOption As New ucParamOption

        For Each objUrlItem In objItems("items") 'url list

            Dim objItem As Object
            objItem = objApiService.getObjectByUrl(objUrlItem)

            If objItem("status") = "D" Then
                Continue For
            End If

            vId = objItem("id")
            vItemName = objItem("name")
            vTitle = objItem("title")
            vDefaultValue = objItem("default_value")
            vRegExp = objItem("regexp")
            vItemSlug = objItem("slug")
            vItemType = objItem("input_type")
            vRequired = objItem("required")
            vAbsoluteUrl = objItem("absolute_url")
            Select Case vItemType
                Case "TEXT"
                    ucText = New ucParaText With {
                                .id = vId,
                                .parameter = vItemName,'"textbox",
                                .title = vTitle,
                                .message = "Testing Mesasge",
                                .value = vDefaultValue,
                                .regExpress = vRegExp,
                                .slug = vItemSlug,
                                .url = vUrl,
                                .cache_url = vCacheUrl,
                                .absolute_url = vAbsoluteUrl,
                                .access_token = access_token,
                                .CurrentForm = Me,
                                .Location = New Point(50, vPosBottom),
                                .required = vRequired
                                }
                    vPosBottom = ucText.Location.Y + ucText.Height + 5
                    ucText.Name = vItemName
                    ucText.Location = iPoint
                    Me.Controls.Add(ucText)
                    iPoint.Y = iPoint.Y + ucText.Height
                    ucText.Show()
                    ucText.showOpject()
                Case "LIST"
                    ucList = New ucParamList With {
                        .id = vId,
                        .parameter = vItemName,'"list",
                        .title = vTitle,
                        .message = "Testing Mesasge",
                        .value = vDefaultValue,
                        .regExpress = vRegExp,
                        .slug = vItemSlug,
                        .url = vUrl,
                        .cache_url = vCacheUrl,
                        .absolute_url = vAbsoluteUrl,
                        .access_token = access_token,
                        .CurrentForm = Me,
                        .Location = New Point(50, vPosBottom),
                        .required = vRequired
                    }
                    vPosBottom = ucList.Location.Y + ucList.Height + 5
                    ucList.Name = vItemName
                    ucList.Location = iPoint

                    Me.Controls.Add(ucList)
                    iPoint.Y = iPoint.Y + ucList.Height
                    ucList.Show()
                    ucList.showOpject()

                Case "RADIO"
                    ucRadio = New ucParamRadio With {
                        .id = vId,
                        .parameter = vItemName,'"choice",
                        .title = vTitle,
                        .message = "",
                        .value = vDefaultValue,
                        .regExpress = vRegExp,
                        .slug = vItemSlug,
                        .url = vUrl,
                        .cache_url = vCacheUrl,
                        .absolute_url = vAbsoluteUrl,
                         .access_token = access_token,
                        .CurrentForm = Me,
                        .Location = New Point(50, vPosBottom),
                        .required = vRequired
                    }
                    ucRadio.Name = vItemName
                    ucRadio.Location = iPoint
                    Me.Controls.Add(ucRadio)
                    iPoint.Y = iPoint.Y + ucRadio.Height
                    'vcc = ucRadio.Height_New
                    ucRadio.Show()
                    ucRadio.AutoSize = True
                    vPosBottom = ucRadio.Location.Y + ucRadio.Height + 5
                    ucRadio.showOpject()
                Case "OPTION"
                    ucOption = New ucParamOption With {
                        .id = vId,
                        .parameter = vItemName,'"option",
                        .title = vTitle,
                        .message = "",
                        .value = vDefaultValue,
                        .regExpress = vRegExp,
                        .slug = vItemSlug,
                        .url = vUrl,
                        .cache_url = vCacheUrl,
                        .absolute_url = vAbsoluteUrl,
                         .access_token = access_token,
                        .CurrentForm = Me,
                        .Location = New Point(50, vPosBottom),
                        .required = vRequired
                    }
                    ucOption.Name = vItemName
                    ucOption.Location = iPoint
                    Me.Controls.Add(ucOption)
                    iPoint.Y = iPoint.Y + ucOption.Height
                    ucOption.Show()
                    ucOption.AutoSize = True
                    vPosBottom = ucOption.Location.Y + ucOption.Height + 5
                    ucOption.showOpject()
                Case "SCRIPT"
            End Select
        Next
    End Sub

    'Sub addParameterToPage(vParameterSlug As String, page As TabPage)
    '    Dim objItems As Object

    '    'objItems = getItemBySlug(vParameterSlug)
    '    objItems = objApiService.getObjectByUrl(vParameterSlug)

    '    Dim vItemName As String
    '    Dim vTitle As String
    '    Dim vDefaultValue As String
    '    Dim vRegExp As String
    '    Dim vItemSlug As String
    '    Dim vItemType As String
    '    Dim vRequired As Boolean
    '    Dim vAbsoluteUrl As String

    '    Dim vPosBottom As Integer = 10
    '    Dim ucText As New ucParaText
    '    Dim ucList As New ucParamList
    '    Dim ucRadio As ucParamRadio

    '    Dim ucOption As New ucParamOption
    '    For Each objUrlItem In objItems("items") 'url list

    '        Dim objItem As Object
    '        objItem = objApiService.getObjectByUrl(objUrlItem)

    '        If objItem("status") = "D" Then
    '            Continue For
    '        End If
    '        vItemName = objItem("name")
    '        vTitle = objItem("title")
    '        vDefaultValue = objItem("default_value")
    '        vRegExp = objItem("regexp")
    '        vItemSlug = objItem("slug")
    '        vItemType = objItem("input_type")
    '        vRequired = objItem("required")
    '        vAbsoluteUrl = objItem("absolute_url")
    '        Select Case vItemType
    '            Case "TEXT"
    '                ucText = New ucParaText With {
    '                            .parameter = "textbox",
    '                            .title = vTitle,
    '                            .message = "Testing Mesasge",
    '                            .value = vDefaultValue,
    '                            .regExpress = vRegExp,
    '                            .slug = vItemSlug,
    '                            .url = vUrl,
    '                            .cache_url = vCacheUrl,
    '                            .absolute_url = vAbsoluteUrl,
    '                            .access_token = access_token,
    '                            .CurrentForm = Me,
    '                            .Location = New Point(50, vPosBottom),
    '                            .required = vRequired
    '                            }
    '                vPosBottom = ucText.Location.Y + ucText.Height + 5
    '                ucText.Name = vItemName
    '                page.Controls.Add(ucText)
    '                ucText.Show()
    '                ucText.showOpject()
    '            Case "LIST"
    '                ucList = New ucParamList With {
    '                    .parameter = "list",
    '                    .title = vTitle,
    '                    .message = "Testing Mesasge",
    '                    .value = vDefaultValue,
    '                    .regExpress = vRegExp,
    '                    .slug = vItemSlug,
    '                    .url = vUrl,
    '                    .cache_url = vCacheUrl,
    '                    .absolute_url = vAbsoluteUrl,
    '                    .access_token = access_token,
    '                    .CurrentForm = Me,
    '                    .Location = New Point(50, vPosBottom),
    '                    .required = vRequired
    '                }
    '                vPosBottom = ucList.Location.Y + ucList.Height + 5
    '                ucList.Name = vItemName
    '                page.Controls.Add(ucList)
    '                ucList.Show()
    '                ucList.showOpject()

    '            Case "RADIO"
    '                ucRadio = New ucParamRadio With {
    '                    .parameter = "choice",
    '                    .title = vTitle,
    '                    .message = "",
    '                    .value = vDefaultValue,
    '                    .regExpress = vRegExp,
    '                    .slug = vItemSlug,
    '                    .url = vUrl,
    '                    .cache_url = vCacheUrl,
    '                    .absolute_url = vAbsoluteUrl,
    '                     .access_token = access_token,
    '                    .CurrentForm = Me,
    '                    .Location = New Point(50, vPosBottom),
    '                    .required = vRequired
    '                }
    '                ucRadio.Name = vItemName
    '                page.Controls.Add(ucRadio)
    '                'vcc = ucRadio.Height_New
    '                ucRadio.Show()
    '                ucRadio.AutoSize = True
    '                vPosBottom = ucRadio.Location.Y + ucRadio.Height + 5
    '                ucRadio.showOpject()
    '            Case "OPTION"
    '                ucOption = New ucParamOption With {
    '                    .parameter = "option",
    '                    .title = vTitle,
    '                    .message = "",
    '                    .value = vDefaultValue,
    '                    .regExpress = vRegExp,
    '                    .slug = vItemSlug,
    '                    .url = vUrl,
    '                    .cache_url = vCacheUrl,
    '                    .absolute_url = vAbsoluteUrl,
    '                     .access_token = access_token,
    '                    .CurrentForm = Me,
    '                    .Location = New Point(50, vPosBottom),
    '                    .required = vRequired
    '                }
    '                ucOption.Name = vItemName
    '                page.Controls.Add(ucOption)
    '                ucOption.Show()
    '                ucOption.AutoSize = True
    '                vPosBottom = ucOption.Location.Y + ucOption.Height + 5
    '                ucOption.showOpject()
    '            Case "SCRIPT"
    '        End Select
    '    Next




    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ' TabControl = Nothing

        Dim aa As Object

        For Each aa In Me.Controls
            If TypeOf aa Is TabControl Then
                aa.Dispose()
            End If
        Next
        CreateObject(gCurrentRouteDetailUrl)
        ' getUserOperation(user_id)


    End Sub

    Private Sub frmParameter_Load(sender As Object, e As EventArgs) Handles Me.Load
        gHostName = System.Net.Dns.GetHostName()
        timerExp.Enabled = True
        'Root_url from Module mdlWMP
        objApiService.Url = Root_url
        objApiService.access_token = access_token
        showObjectName()
        tss1.Text = objApiService.Url

        'getUserOperation(user_id)
        lblOperation.Text = operationPropertyValue
        checkOperationType(operationPropertyValue)


    End Sub

    Sub checkOperationType(Optional vOperationId As String = "")
        Dim operation As Object = Nothing


        'cbProduct.Enabled = False
        'lblProduct.Enabled = False

        'cbWorkOrder.Enabled = False
        'lblWorkOrder.Enabled = False

        If vOperationId <> "" Then
            operation = objApiService.getJsonObject(vUrl + "/api/operation/" & vOperationId & "/")
        Else
            Exit Sub
        End If




        If Not operation Is Nothing Then
            txtSn.BackColor = Color.White
            gOperationType = operation("operation_type")
            gOperationSlug = operation("slug")
            gOperationName = operation("name")

            If operation("operation_type") = "REGISTRATION" Then

                'cbWorkOrder.Enabled = True
                'lblWorkOrder.Enabled = True
                'cbProduct.Enabled = True
                'lblProduct.Enabled = True

                ''-----Fill all WorkOrder----
                'getProducts()
                '---------------------------
            Else
                gCurrentRegExp = ""
            End If
        End If

        'getItemBySlug = json
    End Sub

    'Sub getUserOperation(Optional vUserId As String = "")
    '    Dim operations As Object
    '    Dim operation As Object

    '    'if vUserId is Blank --> get all existing operation
    '    'if exist -->get only authorize operation

    '    If vUserId <> "" Then
    '        operations = objApiService.getJsonObject(vUrl + "/api/profile/" & vUserId & "/operations/") '("operations")
    '    Else
    '        operations = objApiService.getJsonObject(vUrl + "/api/operation/")
    '    End If

    '    Try
    '        If Not operations Is Nothing Then
    '            Dim comboSource As New Dictionary(Of String, String)()

    '            comboSource.Add("", "---")
    '            For Each operation In operations
    '                comboSource.Add(operation("operation")("name") & ":" &
    '                                operation("operation")("title"), operation("operation")("slug")
    '                                )
    '            Next
    '            With cbOperation
    '                .DropDownStyle = ComboBoxStyle.DropDownList
    '                .DataSource = New BindingSource(comboSource, Nothing)
    '                .DisplayMember = "Key"
    '                .ValueMember = "Value"
    '                '.SelectedValue = vDefaultValue
    '                .Items.Insert(0, String.Empty)
    '            End With
    '        End If
    '    Catch ex As Exception

    '    End Try




    '    'getItemBySlug = json
    'End Sub


    'Sub getProducts(Optional vProduct As String = "")
    '    Dim products As Object = Nothing
    '    Dim product As Object = Nothing

    '    products = objApiService.getJsonObject(vUrl + "/api/product/?status=A")("results")



    '    If Not products Is Nothing Then
    '        Dim comboSource As New Dictionary(Of String, String)()
    '        comboSource.Add("", "---")
    '        For Each product In products
    '            comboSource.Add(product("name") & ":" &
    '                            product("title"), product("slug")
    '                            )
    '        Next
    '        With cbProduct
    '            .DropDownStyle = ComboBoxStyle.DropDownList
    '            .DataSource = New BindingSource(comboSource, Nothing)
    '            .DisplayMember = "Key"
    '            .ValueMember = "Value"
    '        End With

    '    End If

    'End Sub

    'Sub getWorkOrders(Optional vProductSlug As String = "")
    '    Dim workorders As Object = Nothing
    '    Dim workorder As Object = Nothing

    '    If vProductSlug <> "" Then
    '        workorders = objApiService.getJsonObject(vUrl + "/api/workorder/?product__slug=" &
    '                                                 vProductSlug & "&status=A")("results")
    '    End If




    '    If Not workorders Is Nothing Then
    '        Dim comboSource As New Dictionary(Of String, String)()

    '        comboSource.Add("", "---")
    '        For Each workorder In workorders
    '            comboSource.Add(workorder("name") & ":" &
    '                            workorder("title"), workorder("slug")
    '                            )
    '        Next
    '        With cbWorkOrder
    '            .DropDownStyle = ComboBoxStyle.DropDownList
    '            .DataSource = New BindingSource(comboSource, Nothing)
    '            .DisplayMember = "Key"
    '            .ValueMember = "Value"
    '        End With
    '    Else
    '        cbWorkOrder.DataSource = Nothing
    '    End If

    'End Sub

    Sub reset()
        clearCurrentRoutingDisplay()
        Dim aa As Object
        Dim controlList As New List(Of Object)
        For Each aa In Me.Controls
            If (TypeOf aa Is mp.ucParaText) Or (TypeOf aa Is mp.ucParamList) _
                Or (TypeOf aa Is mp.ucParamOption) Or (TypeOf aa Is mp.ucParamRadio) Then
                'aa.Dispose()
                controlList.Add(aa)
            End If
        Next

        'Dispose all Custom controls
        For Each aa In controlList
            aa.Dispose()
        Next

        txtComment.Text = ""
        txtSn.Enabled = True
        txtSn.Select(0, txtSn.Text.Length)
        txtSn.Select()
        btnStart.Enabled = True
        btnRefresh.Enabled = False

        btnPass.Enabled = False
        btnFail.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            reset()
            '--Hook --PRE
            If Not executeHook("PRE", btnCancel.Name) Then
                Exit Sub
            End If
            '------------

            If gSerialNumber("perform_resource") = gHostName Then
                setPerformSerialNumber(False, gOperationSlug)
            End If



            '--Hook POST
            If Not executeHook("POST", btnCancel.Name) Then
                Exit Sub
            End If
            '------------
        Catch ex As Exception

        End Try

    End Sub



    Private Sub txtSn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSn.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub btnFail_Click(sender As Object, e As EventArgs) Handles btnFail.Click
        'checkNextCondition(vDefaultNextFailOperation)
        Dim vMoveTo As String = checkNextCondition(gNextFail)
        If vMoveTo <> gNextFail Then
            If MsgBox(gNextTitle & " is correct condition " & vbCrLf &
                   "System will move unit to operation " & vMoveTo,
                   MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Routing Next Condition") = MsgBoxResult.No Then
                MsgBox("cancel")
            End If
        End If


        '--Hook --PRE
        If Not executeHook("PRE", btnFail.Name) Then
            Exit Sub
        End If

        '--Do transaction
        Dim iPerforming As Long
        iPerforming = doPerforming(vMoveTo, False)
        '--Do Parameter trasaction--
        addParametric(iPerforming, user_id)

        '--Hook --POST
        If Not executeHook("POST", btnFail.Name) Then
            Exit Sub
        End If

        reset()
    End Sub

    Private Function addParametric(strPerforming As Integer, strUser As String) As Boolean
        'Dim strId As String
        'Dim strKey As String
        'Dim strValue As String
        Dim aa As Object
        Dim controlList As New List(Of Object)
        For Each aa In Me.Controls
            If (TypeOf aa Is mp.ucParaText) Or (TypeOf aa Is mp.ucParamList) _
                Or (TypeOf aa Is mp.ucParamOption) Or (TypeOf aa Is mp.ucParamRadio) Then
                'aa.Dispose()
                Dim parametric As New clsParametricJson
                With parametric
                    .performing = strPerforming
                    .item = aa.id
                    .value = aa.value
                    .user = user_id
                End With

                Dim output As String = ""
                Dim objResponse As Object
                output = JsonConvert.SerializeObject(parametric)
                objResponse = objApiService.SendRequest(vUrl & "/api/parametric/", output)


                'strId = aa.id
                'strKey = aa.name
                'strValue = aa.value
            End If
        Next
        Return False
    End Function

    Private Sub btnPass_Click(sender As Object, e As EventArgs) Handles btnPass.Click
        '--------------------


        '--------------------
        Dim vMoveTo As String = checkNextCondition(gNextPass)
        If vMoveTo <> gNextPass Then
            If MsgBox(gNextTitle & " is correct condition " & vbCrLf &
                   "System will move unit to operation " & vMoveTo,
                   MsgBoxStyle.YesNo + +MsgBoxStyle.Exclamation, "Routing Next Condition") = MsgBoxResult.No Then
                MsgBox("cancel")
                Exit Sub
            End If

        End If

        '--Hook --PRE
        If Not executeHook("PRE", btnPass.Name) Then
            Exit Sub
        End If

        '--Do transaction
        'doPerforming(vMoveTo, True)
        Dim iPerforming As Long
        iPerforming = doPerforming(vMoveTo, True)


        '--Do Parameter trasaction--
        addParametric(iPerforming, user_id)



        '--Hook --POST
        If Not executeHook("POST", btnPass.Name) Then
            Exit Sub
        End If

        reset()
    End Sub

    Function executeHook(vEvent As String, vControlName As String) As Boolean
        If gCurrentRouteDetailUrl Is Nothing Then
            Return True
        End If

        Dim objRoutingDetail As Object
        objRoutingDetail = objApiService.getObjectByUrl(gCurrentRouteDetailUrl)

        Dim objHook As Object
        For Each vHookUrl In objRoutingDetail("hooks")
            '-----get Hook Object----
            objHook = objApiService.getObjectByUrl(vHookUrl)
            If objHook("status") = "D" Then
                Continue For
            End If
            If objHook("event").ToString.ToLower <> vEvent.ToLower Then
                Continue For
            End If
            If objHook("name").ToString.ToLower <> vControlName.ToLower Then
                Continue For
            End If

            Dim vSnippetUrl As String
            Dim vCode As String
            vSnippetUrl = objHook("snippet")("url")
            Dim objSnippet As Object = Nothing
            objSnippet = objApiService.getObjectByUrl(vSnippetUrl)
            vCode = objSnippet("code")
            'Execute Script-----
            If vCode <> "" Then
                If Not executeScript(vCode) Then
                    Return False
                End If
            End If
            '-------------------

        Next
        Return True
    End Function

    Function doPerforming(vMoveToOperation As String, result As Boolean) As Long
        '----Performing---
        Dim vNote As String = txtComment.Text
        Dim vSnMasterId As Integer
        vSnMasterId = gSerialNumber("id")
        Dim performing As New clsPerformingJson
        With performing
            .sn = vSnMasterId
            .operation = gOperationName 'cbOperation.SelectedValue
            .result = result
            .interval = 1
            .resource_name = gHostName
            .remark = vNote
            .start_time = gSerialNumber("perform_start_date")
            .stop_time = Now.ToLocalTime.ToString("o")
            .user = user_id
        End With
        Dim output As String = ""
        Dim objResponse As Object
        output = JsonConvert.SerializeObject(performing)
        objResponse = objApiService.SendRequest(vUrl & "/api/performing/", output)
        Dim x As String
        x = objResponse("uid")
        '-----------------------
        updateSerialNumber(vMoveToOperation, gOperationName, result)



        'reset()
        Return objResponse("id")
    End Function

    Function updateSerialNumber(moveToOperation As String,
                                operation As String, result As Boolean) As Boolean
        gSerialNumber("current_operation") = moveToOperation
        gSerialNumber("last_operation") = operation
        gSerialNumber("last_modified_date") = Now.ToLocalTime.ToString("o")
        gSerialNumber("last_result") = IIf(result, "true", "false")
        If gCurrentRoutePosition = "L" Then
            gSerialNumber("wip") = "false"
        End If

        gSerialNumber("perform_start_date") = Nothing
        gSerialNumber("perform_operation") = Nothing
        gSerialNumber("perform_resource") = ""
        Dim jss = New JavaScriptSerializer()
        Dim strUpdateJson As String = ""
        strUpdateJson = jss.Serialize(gSerialNumber)

        'update Serial number (Current,Last operation)
        Dim objSnReturned As Object
        objSnReturned = objApiService.SendRequest(gSerialNumber("url"), strUpdateJson,
                                                  "application/json", "PUT")

        gSerialNumberSlug = gSerialNumber("slug")
        tssSn.Text = gSerialNumber("number") & " move to : " & moveToOperation

        Return True
    End Function

    Function setPerformSerialNumber(setPerform As Boolean, Optional operation As String = "") As Boolean
        If setPerform Then
            'Dim objOperation As Object = objApiService.getObjectBySlug("operation", operation)
            gSerialNumber("perform_start_date") = Now.ToLocalTime.ToString("o")
            gSerialNumber("perform_operation") = operation 'objOperation("name")
            gSerialNumber("perform_resource") = gHostName
        Else
            gSerialNumber("perform_start_date") = Nothing
            gSerialNumber("perform_operation") = Nothing
            gSerialNumber("perform_resource") = ""
        End If

        Dim jss = New JavaScriptSerializer()
        Dim strUpdateJson As String = ""
        strUpdateJson = jss.Serialize(gSerialNumber)

        'update Serial number (Current,Last operation)
        Dim objSnReturned As Object
        objSnReturned = objApiService.SendRequest(gSerialNumber("url"), strUpdateJson,
                                                  "application/json", "PUT")
        Return True
    End Function

    'return next operation
    Function checkNextCondition(vNextPass As String) As String
        Dim objRoutingDetail As Object
        'vCurrentRoutingDetailSlug
        'gCurrentRouteUrl
        objRoutingDetail = objApiService.getObjectByUrl(gCurrentRouteDetailUrl)
        'objRoutingDetail = objApiService.getRoutingDetail(gCurrentRoute, operation)

        Dim vNextCodeUrls As Object

        vNextCodeUrls = objRoutingDetail("next_code")


        'No Next Code configuration
        If vNextCodeUrls.length = 0 Then
            Return vNextPass
        End If

        'ANY True -- return True
        Dim vNextCodeUrl As Object
        Dim objSnippet As Object
        Dim vSnippetSlug As String = ""
        Dim vTitle As String
        Dim vNextOpr As String = ""
        Dim vCode As String

        For Each vNextCodeUrl In vNextCodeUrls
            Dim vNextCodeObj As Object
            vNextCodeObj = objApiService.getObjectByUrl(vNextCodeUrl)
            If vNextCodeObj("nexts")(0)("status") = "D" Then
                Continue For
            End If
            vSnippetSlug = vNextCodeObj("snippet")("url")
            objSnippet = objApiService.getObjectByUrl(vSnippetSlug)
            vTitle = vNextCodeObj("nexts")(0)("title")
            vNextOpr = vNextCodeObj("nexts")(0)("operation")
            vCode = objSnippet("code")
            'Execute Script-----
            gNextTitle = ""
            If vCode <> "" And objSnippet("status") = "A" Then
                If executeScript(vCode) Then
                    ' checkAcceptance = True
                    'MsgBox(vTitle & " is correct condition " & vbCrLf &
                    '       "System will move unit to operation " & vNextOpr,
                    '       MsgBoxStyle.Information, "Routing condition information")
                    gNextTitle = vTitle
                    Return vNextOpr
                End If
            End If
            '-------------------
        Next
        Return vNextPass
        'MsgBox("System will move unit to operation " & vDefaultNextOpr,
        '                   MsgBoxStyle.Information, "Default Routing")
    End Function

    'Must Have function
    Dim toolTip1 As New ToolTip()
    Private Sub showObjectName()
        Dim nControl As Control
        Dim strTooltrip As String
        For Each nControl In Me.Controls
            strTooltrip = nControl.Name
            toolTip1.SetToolTip(nControl, strTooltrip)
        Next
        UcAssembly.showOpject()
    End Sub



    Sub verifyCurrentRouting(operationSlug As String, Optional productSlug As String = "",
                           Optional workorderSlug As String = ""
                             )
        lblRouting.Text = ""
        lblNextPass.Text = ""
        lblnextFail.Text = ""

        lblUnitFormat.Text = ""
        'show Routing
        Dim objProduct As Object
        Dim objWorkOrder As Object

        If productSlug <> "" Then
            lblUnitFormat.Text = ""
            objProduct = objApiService.getObjectBySlug("product", productSlug)

            If Not objProduct Is Nothing Then
                gProductRegExp = objProduct("regexp")
                gCurrentRegExp = gProductRegExp

                gProductname = objProduct("name")
                gProductSlug = productSlug

                If Not objProduct("routing") Is Nothing Then
                    gCurrentRoute = objProduct("routing")("name")
                    ' gCurrentRouteSlug = objProduct("routing")("slug")
                    'showCurrentRouting(objProduct("routing")("name"), operation)
                    'Exit Sub
                End If
            End If
        End If

        If workorderSlug <> "" Then
            objWorkOrder = objApiService.getObjectBySlug("workorder", workorderSlug)

            If Not objWorkOrder Is Nothing Then
                gWorkOrdername = objWorkOrder("name")
                gWorkOrderSlug = workorderSlug

                If Not objWorkOrder("regexp") Is Nothing Then
                    gCurrentRegExp = objWorkOrder("regexp")
                    'Else
                    'gCurrentRegExp = gProductRegExp
                End If

                'lblUnitFormat.Text = gCurrentRegExp

                If Not objWorkOrder("routing") Is Nothing Then
                    gCurrentRoute = objWorkOrder("routing")("name")
                    'gCurrentRouteSlug = objWorkOrder("routing")("slug")
                    'showCurrentRouting(objWorkOrder("routing")("name"), operation)
                    'Exit Sub
                End If

            End If
        End If


        lblUnitFormat.Text = gCurrentRegExp
        showCurrentRouting(gCurrentRoute, gOperationName)
        '------------
    End Sub

    Sub clearCurrentRoutingDisplay()
        lblRouting.Text = ""
        lblNextPass.Text = ""
        lblnextFail.Text = ""
        lblUnitFormat.Text = ""
    End Sub

    Sub showCurrentRouting(routing As String, operation As String)
        Try

            lblNextPass.Text = "[Not defined]"
            lblnextFail.Text = "[Not defined]"
            Dim objRouting As Object
            Dim objRoutingDetail As Object
            objRouting = objApiService.getObjectBySlug("routing", routing)
            If Not objRouting Is Nothing Then
                lblRouting.Text = objRouting("name")
                objRoutingDetail = objApiService.getObjectByUrl(vUrl + "/api/routing-detail/?routing=" &
                                                         routing & "&operation=" & operation &
                                                            "&status=A")
                If Not objRoutingDetail("results") Is Nothing Then
                    lblNextPass.Text = objRoutingDetail("results")(0)("next_pass")
                    lblnextFail.Text = objRoutingDetail("results")(0)("next_fail")
                    gCurrentRoutePosition = objRoutingDetail("results")(0)("position")
                    gCurrentRouteDetailSlug = objRoutingDetail("results")(0)("slug")
                    If gCurrentRoutePosition = "L" Then
                        lblNextPass.Text = lblNextPass.Text & " -->END Process"
                    End If

                End If

            End If
        Catch ex As Exception

        End Try

    End Sub





    'Private Sub cbWorkOrder_SelectionChangeCommitted(sender As Object, e As EventArgs) 
    '    Try
    '        Dim key As String = DirectCast(cbWorkOrder.SelectedItem, KeyValuePair(Of String, String)).Key
    '        Dim value As String = DirectCast(cbWorkOrder.SelectedItem, KeyValuePair(Of String, String)).Value
    '        Dim Productvalue As String = DirectCast(cbProduct.SelectedItem, KeyValuePair(Of String, String)).Value
    '        'Dim Operationvalue As String = DirectCast(cbOperation.SelectedItem, KeyValuePair(Of String, String)).Value
    '        If key = "" Then
    '            Exit Sub
    '        End If
    '        verifyCurrentRouting(gOperationSlug, Productvalue, value)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub cbProduct_SelectionChangeCommitted(sender As Object, e As EventArgs) 
    '    Dim key As String = DirectCast(cbProduct.SelectedItem, KeyValuePair(Of String, String)).Key
    '    Dim ProductSlug As String = DirectCast(cbProduct.SelectedItem, KeyValuePair(Of String, String)).Value 'slug

    '    'Dim OperationSlug As String = DirectCast(cbOperation.SelectedItem, KeyValuePair(Of String, String)).Value 'slug

    '    If key = "" Then
    '        Exit Sub
    '    End If
    '    getWorkOrders(ProductSlug)
    '    verifyCurrentRouting(gOperationSlug, ProductSlug, "")
    'End Sub

    'Private Sub cbOperation_SelectionChangeCommitted(sender As Object, e As EventArgs)
    '    clearCurrentRoutingDisplay()
    '    Dim key As String = DirectCast(cbOperation.SelectedItem, KeyValuePair(Of String, String)).Key
    '    Dim value As String = DirectCast(cbOperation.SelectedItem, KeyValuePair(Of String, String)).Value 'slug
    '    If key = "" Then
    '        Exit Sub
    '    End If
    '    checkOperationType(value)
    '    ' ValueType = (KeyValuePair(Of key, value))cbOperation.SelectedItem).
    'End Sub



    Private Sub txtSn_TextChanged(sender As Object, e As EventArgs) Handles txtSn.TextChanged
        btnStart.Enabled = False
        If gCurrentRegExp = "" Then
            txtSn.BackColor = Color.White
            btnStart.Enabled = True
            Exit Sub
        End If
        Dim reg_exp As New Regex("^" & gCurrentRegExp & "$")
        If reg_exp.IsMatch(txtSn.Text) Then
            btnStart.Enabled = True
            txtSn.BackColor = Color.White
        Else
            txtSn.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub timerExp_Tick(sender As Object, e As EventArgs) Handles timerExp.Tick
        Dim elapsed_time As TimeSpan

        Dim stop_time As Date
        stop_time = exp_token
        elapsed_time = stop_time.Subtract(Now)
        lblExpToken.Text =
                elapsed_time.TotalMinutes.ToString("0.00")

        'Root_url --> from module mdlWMP
        If elapsed_time.TotalSeconds < 20 Then
            timerExp.Enabled = False

            Dim clsAuthen As clsAuthentication = New clsAuthentication(
            Root_url, login_user, login_password)

            Dim vTokenResult As Boolean
            vTokenResult = clsAuthen.requestToken()

            'Assign public variable (MUST -- Very Importance)
            user_id = clsAuthen.user_id_token
            access_token = clsAuthen.access_token
            'refresh_token = clsAuthen.requestToken

            objApiService.access_token = access_token

            Dim ii As Integer = clsAuthen.exp
            Dim epoch = New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            exp_token = epoch.AddSeconds(ii).ToLocalTime
            timerExp.Enabled = True
        End If



    End Sub



    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        reset()
    End Sub

    Private Sub frmParameter_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

    End Sub

    Private Sub cbWorkOrder_SelectedIndexChanged(sender As Object, e As EventArgs) 

    End Sub

    Private Sub lblRouting_Click(sender As Object, e As EventArgs) Handles lblRouting.Click
        'Open URL
        Process.Start(vUrl & "/routing/detail/" & gCurrentRouteDetailSlug)

    End Sub

    Private Sub tssSn_Click(sender As Object, e As EventArgs) Handles tssSn.Click
        Process.Start(vUrl & "/serialnumber/" & gSerialNumberSlug)
    End Sub

    Private Sub cbOperation_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSnippet_Click(sender As Object, e As EventArgs) Handles btnSnippet.Click
        frmSnippet.targetForm = Me
        frmSnippet.Show()
    End Sub








    '------------------
End Class