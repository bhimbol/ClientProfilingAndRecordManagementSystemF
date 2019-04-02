Public Class frmAddEditViewClients

    Public Sub fillBeneficiariesForm(id As String)
        Dim cb As New ClientsBeneficiaries
        dgvBeneficiaries.DataSource = cb.findbyClientID(id)
        dgvBeneficiaries.Columns(0).HeaderText = "Beneficiary's ID"
        dgvBeneficiaries.Columns(1).HeaderText = "Client's ID"
        dgvBeneficiaries.Columns(0).Visible = False
        dgvBeneficiaries.Columns(1).Visible = False

        dgvBeneficiaries.Columns(2).HeaderText = "FULL NAME"
        dgvBeneficiaries.Columns(3).HeaderText = "BIRTH DATE (dd/mm/yyyy)"
        dgvBeneficiaries.Columns(4).HeaderText = "BIRTH PLACE"
        dgvBeneficiaries.Columns(5).HeaderText = "RELATIONSHIP"
        dgvBeneficiaries.Columns(6).HeaderText = "OCCUPATION"
        dgvBeneficiaries.Columns(7).HeaderText = "PERCENT SHARE"
        btnBUpdate.Visible = False
    End Sub
    Private Sub fillDataForms()
        txtClientsID.Text = frmClients.dgvClientsSelectedRow.Cells("ID").Value.ToString
        txtLastname.Text = frmClients.dgvClientsSelectedRow.Cells("LASTNAME").Value.ToString
        txtFirstname.Text = frmClients.dgvClientsSelectedRow.Cells("FIRSTNAME").Value.ToString
        txtMiddlename.Text = frmClients.dgvClientsSelectedRow.Cells("MIDDLENAME").Value.ToString
        txtSLastname.Text = frmClients.dgvClientsSelectedRow.Cells("SPOUSELASTNAME").Value.ToString
        txtSFirstname.Text = frmClients.dgvClientsSelectedRow.Cells("SPOUSEFIRSTNAME").Value.ToString
        txtSMiddlename.Text = frmClients.dgvClientsSelectedRow.Cells("SPOUSEMIDDLENAME").Value.ToString
        txtBirthplace.Text = frmClients.dgvClientsSelectedRow.Cells("BIRTHPLACE").Value.ToString
        txtHeight.Text = frmClients.dgvClientsSelectedRow.Cells("HEIGHT").Value.ToString
        txtweight.Text = frmClients.dgvClientsSelectedRow.Cells("WEIGHT").Value.ToString
        txtresidenceaddress.Text = frmClients.dgvClientsSelectedRow.Cells("RESIDENCEADDRESS").Value.ToString
        txtcpnumber.Text = frmClients.dgvClientsSelectedRow.Cells("CPNUMBER").Value.ToString
        txttelephonenumber.Text = frmClients.dgvClientsSelectedRow.Cells("TELEPHONENUMBER").Value.ToString
        txtemailaddress.Text = frmClients.dgvClientsSelectedRow.Cells("EMAILADRESS").Value.ToString
        txtOccupation.Text = frmClients.dgvClientsSelectedRow.Cells("OCCUPATION").Value.ToString
        txtWorkSalary.Text = frmClients.dgvClientsSelectedRow.Cells("WORKSALARY").Value.ToString
        txtBusinessIncome.Text = frmClients.dgvClientsSelectedRow.Cells("BUSINESSINCOME").Value.ToString
        txtOtherSource.Text = frmClients.dgvClientsSelectedRow.Cells("OTHERSOURCE").Value.ToString
        txtCompanyName.Text = frmClients.dgvClientsSelectedRow.Cells("COMPANYNAME").Value.ToString
        txtCompanyAddress.Text = frmClients.dgvClientsSelectedRow.Cells("COMPANYADDRESS").Value.ToString
        txtCompanyConctactNumber.Text = frmClients.dgvClientsSelectedRow.Cells("COMPANYCONTACT").Value.ToString
        txtNatureofBusiness.Text = frmClients.dgvClientsSelectedRow.Cells("NATUREOFBUSINESS").Value.ToString
        txtTaxIDNumber.Text = frmClients.dgvClientsSelectedRow.Cells("TAXIDNUMBER").Value.ToString
        txtSSSGSISNumber.Text = frmClients.dgvClientsSelectedRow.Cells("SSS_GSISNUMBER").Value.ToString
        txtsubanswer2.Text = frmClients.dgvClientsSelectedRow.Cells("ANSWERSUB2").Value.ToString
        txtsubanswer3.Text = frmClients.dgvClientsSelectedRow.Cells("ANSWERSUB3").Value.ToString
        dtpBdate.Value = frmClients.dgvClientsSelectedRow.Cells("BIRTHDATE").Value.ToString

        Dim gender As String = frmClients.dgvClientsSelectedRow.Cells("GENDER").Value.ToString
        Dim civilstatus As String = frmClients.dgvClientsSelectedRow.Cells("CIVILSTATUS").Value.ToString
        Dim answersub1 As String = frmClients.dgvClientsSelectedRow.Cells("ANSWERSUB1").Value.ToString

        If gender = "Male" Then
            rbGenderM.Checked = True
        Else
            rbGenderF.Checked = True
        End If
        If civilstatus = "Single" Then
            rbSingle.Checked = True
        ElseIf civilstatus = "Married" Then
            rbMarried.Checked = True
        Else
            rbWidowed.Checked = True
        End If
        If answersub1 = "YES" Then
            rbYES.Checked = True
        Else
            rbNo.Checked = True
        End If

        fillBeneficiariesForm(txtClientsID.Text)
    End Sub
    Private Sub frmAddEditViewClients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmClients.action = "ADD" Then
            btnAddClient.Enabled = True
            btnUpdateClient.Enabled = False
            panelBeneficiaries.Enabled = False
        ElseIf frmClients.action = "EDIT" Then
            btnAddClient.Enabled = False
            btnUpdateClient.Enabled = True
            panelBeneficiaries.Enabled = True
            fillDataForms()
        ElseIf frmClients.action = "VIEW" Then
            btnAddClient.Enabled = False
            btnUpdateClient.Enabled = False
            'code to view
        End If
    End Sub
    Private Sub btnAddClient_Click(sender As Object, e As EventArgs) Handles btnAddClient.Click
        Dim gender As String = String.Empty
        Dim civilstatus As String = String.Empty
        Dim answer1 As String = String.Empty
        If rbGenderM.Checked = True Then gender = "Male"
        If rbGenderF.Checked = True Then gender = "Female"
        If rbSingle.Checked = True Then civilstatus = "Single"
        If rbMarried.Checked = True Then civilstatus = "Married"
        If rbWidowed.Checked = True Then civilstatus = "Widowed"
        If rbYES.Checked = True Then answer1 = "YES"
        If rbNo.Checked = True Then answer1 = "NO"
        Dim client As New Clients
        Dim resultID As String
        resultID = client.add(txtLastname.Text, txtFirstname.Text, txtMiddlename.Text, txtSLastname.Text, txtSFirstname.Text,
                   txtSMiddlename.Text, txtBirthplace.Text, txtHeight.Text, txtweight.Text, txtresidenceaddress.Text,
                   txtcpnumber.Text, txttelephonenumber.Text, txtemailaddress.Text, txtOccupation.Text, txtWorkSalary.Text,
                   txtBusinessIncome.Text, txtOtherSource.Text, txtCompanyName.Text, txtCompanyAddress.Text,
                   txtCompanyConctactNumber.Text, txtNatureofBusiness.Text, txtTaxIDNumber.Text, txtSSSGSISNumber.Text,
                   answer1, txtsubanswer2.Text, txtsubanswer3.Text, dtpBdate.Value, gender, civilstatus)

        If resultID = "FAILED" Then
            MsgBox("Error Occured. Please check your Entry.")
        Else
            MsgBox("Record successfully added.")
            txtClientsID.Text = resultID
            fillBeneficiariesForm(resultID)
            btnAddClient.Enabled = False
            btnUpdateClient.Enabled = True
            panelBeneficiaries.Enabled = True
            frmClients.frmClients_Load(sender, e)
            'Me.Close()
        End If
        client = Nothing
    End Sub

    Private Sub btnUpdateClient_Click(sender As Object, e As EventArgs) Handles btnUpdateClient.Click
        Dim gender As String = String.Empty
        Dim civilstatus As String = String.Empty
        Dim answer1 As String = String.Empty
        If rbGenderM.Checked = True Then gender = "Male"
        If rbGenderF.Checked = True Then gender = "Female"
        If rbSingle.Checked = True Then civilstatus = "Single"
        If rbMarried.Checked = True Then civilstatus = "Married"
        If rbWidowed.Checked = True Then civilstatus = "Widowed"
        If rbYES.Checked = True Then answer1 = "YES"
        If rbNo.Checked = True Then answer1 = "NO"
        Dim client As New Clients
        If client.update(txtLastname.Text, txtFirstname.Text, txtMiddlename.Text, txtSLastname.Text, txtSFirstname.Text,
                   txtSMiddlename.Text, txtBirthplace.Text, txtHeight.Text, txtweight.Text, txtresidenceaddress.Text,
                   txtcpnumber.Text, txttelephonenumber.Text, txtemailaddress.Text, txtOccupation.Text, txtWorkSalary.Text,
                   txtBusinessIncome.Text, txtOtherSource.Text, txtCompanyName.Text, txtCompanyAddress.Text,
                   txtCompanyConctactNumber.Text, txtNatureofBusiness.Text, txtTaxIDNumber.Text, txtSSSGSISNumber.Text,
                   answer1, txtsubanswer2.Text, txtsubanswer3.Text, dtpBdate.Value, gender, civilstatus, txtClientsID.Text) = True Then
            MsgBox("Record successfully updated.")
            frmClients.frmClients_Load(sender, e)
            Me.Close()
            Me.Dispose()
        Else
            MsgBox("Error Occured. Please check your Entry.")
        End If
        client = Nothing
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnAddBeneficiary_Click(sender As Object, e As EventArgs) Handles btnAddBeneficiary.Click
        Dim cb As New ClientsBeneficiaries
        If cb.add(txtClientsID.Text, txtBFullname.Text, dtpBBirthDate.Value, txtBBirthPlace.Text, txtBRelationship.Text, txtBOccupation.Text, txtBShare.Text) <> "FAILED" Then
            MsgBox("Beneficiary successfully added.")
            fillBeneficiariesForm(txtClientsID.Text)
            txtBFullname.Clear()
            txtBBirthPlace.Clear()
            txtBRelationship.Clear()
            txtBOccupation.Clear()
            txtBShare.Clear()
        Else
            MsgBox("Error occured, please check entry.")
        End If
        cb = Nothing
    End Sub
    Private Sub frmAddEditViewClients_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
    Private Sub btnRemoveBeneficiary_Click(sender As Object, e As EventArgs) Handles btnRemoveBeneficiary.Click
        Dim cb As New ClientsBeneficiaries
        If dgvBeneficiaries.Rows.Count > 0 Then
            For Each c In dgvBeneficiaries.SelectedRows
                If MsgBox("Delete ID: " & c.Cells("ID").Value.ToString & c.Cells("FULLNAME").value.ToString & ".", vbYesNo, "Delete Beneficiary") = MsgBoxResult.Yes Then
                    cb.delete(c.Cells("ID").value.ToString)
                End If
            Next
        End If
        fillBeneficiariesForm(txtClientsID.Text)
        cb = Nothing
    End Sub

    Private Sub dgvBeneficiaries_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBeneficiaries.CellDoubleClick
        btnBUpdate.Visible = True
        btnAddBeneficiary.Enabled = False
        If dgvBeneficiaries.Rows.Count > 0 Then
            txtBFullname.Text = dgvBeneficiaries.SelectedRows(0).Cells("FULLNAME").Value.ToString
            dtpBBirthDate.Value = dgvBeneficiaries.SelectedRows(0).Cells("BIRTHDATE").Value.ToString
            txtBBirthPlace.Text = dgvBeneficiaries.SelectedRows(0).Cells("BIRTHPLACE").Value.ToString
            txtBRelationship.Text = dgvBeneficiaries.SelectedRows(0).Cells("RELATIONSHIP").Value.ToString
            txtBOccupation.Text = dgvBeneficiaries.SelectedRows(0).Cells("OCCUPATION").Value.ToString
            txtBShare.Text = dgvBeneficiaries.SelectedRows(0).Cells("SHARE").Value.ToString
        End If
    End Sub

    Private Sub btnBUpdate_Click(sender As Object, e As EventArgs) Handles btnBUpdate.Click
        Dim bid As String
        Dim cb As New ClientsBeneficiaries
        bid = dgvBeneficiaries.SelectedRows(0).Cells("ID").Value.ToString
        If cb.update(bid, txtBFullname.Text, dtpBBirthDate.Value, txtBBirthPlace.Text, txtBRelationship.Text, txtBOccupation.Text, txtBShare.Text) <> False Then
            MsgBox("Beneficiary updated.")
            fillBeneficiariesForm(txtClientsID.Text)
        Else
            MsgBox("Error occured, please check entry.")
        End If
        txtBFullname.Clear()
        txtBBirthPlace.Clear()
        txtBRelationship.Clear()
        txtBOccupation.Clear()
        txtBShare.Clear()
        btnBUpdate.Visible = False
        btnAddBeneficiary.Enabled = True
    End Sub

    Private Sub dgvBeneficiaries_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBeneficiaries.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class