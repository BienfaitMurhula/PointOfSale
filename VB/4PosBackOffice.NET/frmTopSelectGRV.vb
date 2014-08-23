Option Strict Off
Option Explicit On
Friend Class frmTopSelectGRV
    Inherits System.Windows.Forms.Form
    Dim optType As New List(Of RadioButton)
    Dim Frame1 As New List(Of GroupBox)
	Private Sub loadLanguage()
		
		'frmTopSelectGRV = No Code  [Purchase Performance]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmTopSelectGRV.Caption = rsLang("LanguageLayoutLnk_Description"): frmTopSelectGRV.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1172 'Report Options|Checked
		If rsLang.RecordCount Then Frame1(0).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame1(0).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2152 'Normal Item Listing|Checked
		If rsLang.RecordCount Then optType(0).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optType(0).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2153 'Items per Group|Checked
		If rsLang.RecordCount Then optType(1).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optType(1).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2154 'Group Totals|Checked
		If rsLang.RecordCount Then optType(2).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optType(2).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1173 'Group On|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1174 'Page break after each group|Checked
		If rsLang.RecordCount Then chkPageBreak.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkPageBreak.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1175 'Report Sort Order|Checked
		If rsLang.RecordCount Then Frame1(1).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame1(1).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2158 'Sort Field|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2159 'Sort Order|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1178 'Report Filter|Checked
		If rsLang.RecordCount Then Frame1(2).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame1(2).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdGroup.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdGroup.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1181 'Show/Print Report|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmTopSelectGRV.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	Private Sub cmdGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGroup.Click
		Dim rs As ADODB.Recordset
		Dim lID As Integer
		cnnDBreport.Execute("DELETE aftDataItem.* From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" & gPersonID & "));")
		
		cnnDBreport.Execute("DELETE aftData.* From aftData WHERE (((aftData.ftData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO aftData ( ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading ) SELECT LinkData.LinkData_PersonID, LinkData.LinkData_FieldName, LinkData.LinkData_SQL, LinkData.LinkData_Heading From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO aftDataItem ( ftDataItem_PersonID, ftDataItem_FieldName, ftDataItem_ID ) SELECT LinkDataItem.LinkDataItem_PersonID, LinkDataItem.LinkDataItem_FieldName, LinkDataItem.LinkDataItem_ID From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
		frmFilter.Close()
		frmFilter.buildCriteria("Sale")
		frmFilter.loadFilter("Sale")
		frmFilter.buildCriteria("Sale")
		
		cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = '" & Replace(frmFilter.gHeading, "'", "''") & "', Link.Link_SQL = '" & Replace(frmFilter.gCriteria, "'", "''") & "' WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("DELETE LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO LinkData ( LinkData_LinkID, LinkData_SectionID, LinkData_PersonID, LinkData_FieldName, LinkData_SQL, LinkData_Heading ) SELECT 2, 1, aftData.ftData_PersonID, aftData.ftData_FieldName, aftData.ftData_SQL, aftData.ftData_Heading From aftData WHERE (((aftData.ftData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO LinkDataItem ( LinkDataItem_LinkID, LinkDataItem_SectionID, LinkDataItem_PersonID, LinkDataItem_FieldName, LinkDataItem_ID ) SELECT 2, 1, aftDataItem.ftDataItem_PersonID, aftDataItem.ftDataItem_FieldName, aftDataItem.ftDataItem_ID From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" & gPersonID & "));")
		lblGroup.Text = frmFilter.gHeading
	End Sub
	Private Sub setup()
		Dim rs As ADODB.Recordset
		rs = getRSreport("SELECT Link.Link_PersonID From Link WHERE (((Link.Link_PersonID)=" & gPersonID & "));")
		If rs.BOF Or rs.EOF Then
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 1, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 1, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 2, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 2, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 3, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 4, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 5, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 6, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 7, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 8, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 9, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 10, 3, " & gPersonID & ", '', '';")
		End If
		
		rs = getRSreport("SELECT Link.Link_Name From Link WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" & gPersonID & "));")
		lblGroup.Text = rs.Fields("Link_Name").Value
	End Sub
	
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
		Dim rs As ADODB.Recordset
		Dim sql As String
		Dim rsData As ADODB.Recordset
		Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
		Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
		ReportNone.Load("cryNoRecords.rpt")
		Dim lOrder As String
		
		Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition
		
		Select Case Me.cmbSortField.SelectedIndex
			Case 0
				lOrder = "StockItem_Name"
			Case 1
				lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			Case 2
				lOrder = "[exclusiveSum]-[depositSum]"
			Case 3
				lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			Case 4
				lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			Case 5
				lOrder = "StockListGRV.quantitySum"
				
		End Select
		
		If Me.cmbSort.SelectedIndex Then lOrder = lOrder & " DESC"
		lOrder = " ORDER BY " & lOrder
		
		'UPGRADE_NOTE: Object Report may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Report = Nothing
		
		If Me.optType(0).Checked Then
            Report.Load("cryStockitemTop1GRV.rpt")
		ElseIf Me.optType(1).Checked Then 
            Report.Load("cryStockitemTopByGroupGRV.rpt")
		Else
            Report.Load("cryStockitemTopGroupGRV.rpt")
		End If
		Do While Report.DataDefinition.SortFields.Count
			''Report.RecordSortFields.delete(1)
		Loop 
		
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
		Report.SetParameterValue("txtCompanyName",rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
		rs.Close()
		rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
        Report.SetParameterValue("txtFilter", Replace(rs.Fields("Link_Name").Value, "''", "'"))
		
		If Me.optType(0).Checked Then
			If rs.Fields("Link_SQL").Value <> "" Then
				sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListGRV.inclusiveSum AS inclusive, StockListGRV.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockListGRV.quantitySum AS quantity, StockListGRV.listCostSum AS listCost, StockListGRV.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID "
			Else
				Select Case Me.cmbSortField.SelectedIndex
					Case 0
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListGRV.inclusiveSum AS inclusive, StockListGRV.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockListGRV.quantitySum AS quantity, StockListGRV.listCostSum AS listCost, StockListGRV.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID "
					Case 1
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
						'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
					Case 2
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
						'lOrder = "[exclusiveSum]-[depositSum]"
					Case 3
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
						'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
					Case 4
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
						'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
					Case 5
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockListGRV.quantitySum "
						'lOrder = "StockListGRV.quantitySum"
				End Select
				
			End If
			
		ElseIf Me.optType(1).Checked Then 
			If rs.Fields("Link_SQL").Value <> "" Then
				sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListGRV.inclusiveSum AS inclusive, StockListGRV.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockListGRV.quantitySum AS quantity, StockListGRV.listCostSum AS listCost, StockListGRV.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID "
			Else
				Select Case Me.cmbSortField.SelectedIndex
					Case 0
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
					Case 1
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
						'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
					Case 2
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
						'lOrder = "[exclusiveSum]-[depositSum]"
					Case 3
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
						'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
					Case 4
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
						'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
					Case 5
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
						sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockListGRV.quantitySum "
						'lOrder = "StockListGRV.quantitySum"
				End Select
				'sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
				'sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			End If
			Select Case Me.cmbGroup.SelectedIndex
				Case 0
					sql = Replace(sql, "StockGroup", "PricingGroup")
                    Report.SetParameterValue("txtTitle", "Purchase Performance - by Pricing Group")
				Case 1
                    Report.SetParameterValue("txtTitle", "Purchase Performance - by Stock Group")
				Case 2
					sql = Replace(sql, "StockGroup", "Supplier")
					sql = Replace(sql, "aSupplier", "Supplier")
                    Report.SetParameterValue("txtTitle", "Purchase Performance - by Supplier")
				Case 3
					sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListGRV.inclusiveSum AS inclusive, StockListGRV.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockListGRV.quantitySum AS quantity, StockListGRV.listCostSum AS listCost, StockListGRV.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID "
                    Report.SetParameterValue("txtTitle", "Purchase Performance - by Report Group")
			End Select
			
			If Me.chkPageBreak.CheckState Then
				Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
			Else
				Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
			End If
			
		Else
			'If rs("Link_SQL") <> "" Then
			sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListGRV.inclusiveSum AS inclusive, StockListGRV.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockListGRV.quantitySum AS quantity, StockListGRV.listCostSum AS listCost, StockListGRV.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID "
			'Else
			'    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListGRV.inclusiveSum) AS inclusive, Sum(StockListGRV.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListGRV.quantitySum) AS quantity, Sum(StockListGRV.listCostSum) AS listCost, Sum(StockListGRV.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			'    sql = sql & "FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			'End If
			Select Case Me.cmbGroup.SelectedIndex
				Case 0
					sql = Replace(sql, "StockGroup", "PricingGroup")
                    Report.SetParameterValue("txtTitle", "Purchase Performance - by Pricing Group")
				Case 1
                    Report.SetParameterValue("txtTitle", "Purchase Performance - by Stock Group")
				Case 2
					sql = Replace(sql, "StockGroup", "Supplier")
					sql = Replace(sql, "aSupplier", "Supplier")
                    Report.SetParameterValue("txtTitle", "Purchase Performance - by Supplier")
				Case 3
					sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListGRV.inclusiveSum AS inclusive, StockListGRV.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockListGRV.quantitySum AS quantity, StockListGRV.listCostSum AS listCost, StockListGRV.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockListGRV INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockListGRV.aStockItem1.StockItemID = aStockItem1.StockItemID "
                    Report.SetParameterValue("txtTitle", "Purchase Performance - by Report Group")
			End Select
			
			If Me.chkPageBreak.CheckState Then
				Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
			Else
				Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
			End If
		End If
		
		'for customer
		'SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListGRV.inclusiveSum AS inclusive, StockListGRV.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockListGRV.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aCustomer.Customer_InvoiceName AS department
		'FROM aCustomer INNER JOIN (CustomerTransaction INNER JOIN (Sale INNER JOIN (SaleItem INNER JOIN (StockList INNER JOIN aStockItem1 ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID) ON SaleItem.SaleItem_StockItemID = StockList.SaleItem_StockItemID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID
		'WHERE (((aCustomer.CustomerID)=2) AND ((CustomerTransaction.CustomerTransaction_TransactionTypeID)=2)) OR (((CustomerTransaction.CustomerTransaction_TransactionTypeID)=3));
		
		If rs.Fields("Link_SQL").Value = "" Then
		Else
			sql = sql & rs.Fields("Link_SQL").Value
		End If
		
		sql = sql & lOrder
		Debug.Print(sql)
		rs = getRSreport(sql)
		
		If rs.BOF Or rs.EOF Then
			ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
			ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
			frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		
		'Report.VerifyOnEveryPrint = True
		Report.Database.Tables(1).SetDataSource(rs)
        'Report.Database.SetDataSource(rs, 3)
		'Report.VerifyOnEveryPrint = True
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
	End Sub
	
	Private Sub cmdLoad_Click__OLD()
		Dim rs As ADODB.Recordset
		Dim sql As String
		Dim rsData As ADODB.Recordset
		Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
		Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
		ReportNone.Load("cryNoRecords.rpt")
		Dim lOrder As String
		
		Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition
		
		Select Case Me.cmbSortField.SelectedIndex
			Case 0
				lOrder = "StockItem_Name"
			Case 1
				lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			Case 2
				lOrder = "[exclusiveSum]-[depositSum]"
			Case 3
				lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			Case 4
				lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			Case 5
				lOrder = "StockList.quantitySum"
				
		End Select
		
		If Me.cmbSort.SelectedIndex Then lOrder = lOrder & " DESC"
		lOrder = " ORDER BY " & lOrder
		
		'UPGRADE_NOTE: Object Report may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Report = Nothing
		
		If Me.optType(0).Checked Then
            Report.Load("cryStockitemTop1.rpt")
		ElseIf Me.optType(1).Checked Then 
            Report.Load("cryStockitemTopByGroup.rpt")
		Else
            Report.Load("cryStockitemTopGroup.rpt")
		End If
		Do While Report.DataDefinition.SortFields.Count
			''Report.RecordSortFields.delete(1)
		Loop 
		
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
		Report.SetParameterValue("txtCompanyName",rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
		rs.Close()
		rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
        Report.SetParameterValue("txtFilter", Replace(rs.Fields("Link_Name").Value, "''", "'"))
		
		If Me.optType(0).Checked Then
			sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem INNER JOIN aStockGroup ON aStockItem.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem.StockItemID "
		Else
			sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem INNER JOIN aStockGroup ON aStockItem.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem.StockItemID "
			Select Case Me.cmbGroup.SelectedIndex
				Case 0
					sql = Replace(sql, "StockGroup", "PricingGroup")
                    Report.SetParameterValue("txtTitle", "Purchase Performance - by Pricing Group")
				Case 1
                    Report.SetParameterValue("txtTitle", "Purchase Performance - by Stock Group")
				Case 2
					sql = Replace(sql, "StockGroup", "Supplier")
					sql = Replace(sql, "aSupplier", "Supplier")
                    Report.SetParameterValue("txtTitle", "Purchase Performance - by Supplier")
					
			End Select
			
			If Me.chkPageBreak.CheckState Then
				Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
			Else
				Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
			End If
		End If
		
		If rs.Fields("Link_SQL").Value = "" Then
		Else
			sql = sql & rs.Fields("Link_SQL").Value
		End If
		
		sql = sql & lOrder
		'Debug.Print sql
		rs = getRSreport(sql)
		
		If rs.BOF Or rs.EOF Then
			ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
			ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
			frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		
		'Report.VerifyOnEveryPrint = True
		Report.Database.Tables(1).SetDataSource(rs)
        'Report.Database.SetDataSource(rs, 3)
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
	End Sub
	
	Private Sub frmTopSelectGRV_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			Me.Close()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub frmTopSelectGRV_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        optType.AddRange(New RadioButton() {_optType_0, _optType_1, _optType_2})
        Frame1.AddRange(New GroupBox() {_Frame1_0, _Frame1_1, _Frame1_2})
        Dim rb As New RadioButton
        For Each rb In optType
            AddHandler rb.CheckedChanged, AddressOf optType_CheckedChanged
        Next

        setup()
		loadLanguage()
		Me.cmbGroup.SelectedIndex = 0
		Me.cmbSort.SelectedIndex = 0
		Me.cmbSortField.SelectedIndex = 0
	End Sub
	
	'UPGRADE_WARNING: Event optType.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optType_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles optType.CheckedChanged
        If eventSender.Checked Then
            Dim opt As New RadioButton
            opt = DirectCast(eventSender, RadioButton)
            Dim Index As Integer = GetIndexer(opt, optType)
            If Index Then
                cmbGroup.Enabled = True
            Else
                cmbGroup.Enabled = False
            End If
            Me.chkPageBreak.Enabled = (Index = 1)
        End If
    End Sub
End Class