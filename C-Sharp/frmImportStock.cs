using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DpSdkEngLib;
using DPSDKOPSLib;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
 // ERROR: Not supported in C#: OptionDeclaration
using VB = Microsoft.VisualBasic;
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmImportStock : System.Windows.Forms.Form
	{
		string st_Name;
		bool dReceipt;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2421;
			//Import|Checked
			if (modRecordSet.rsLang.RecordCount){My.MyProject.Forms.frmExport.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;My.MyProject.Forms.frmExport.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2427;
			//HandHeld Stock Take: (Item Barcode, Item Quantity)]
			if (modRecordSet.rsLang.RecordCount){lblHeading.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblHeading.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2428;
			//File Path|Checked
			if (modRecordSet.rsLang.RecordCount){Label2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmImportStock.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		private void ExRecipe()
		{
			string sql = null;
			string sqlInsert = null;
			string sqlUp = null;
			short K_Value = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			//Catalogue baracorde
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset rt = default(ADODB.Recordset);
			ADODB.Recordset rd = default(ADODB.Recordset);

			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT * FROM RecieptEx Order By StockCode Asc");
			while (rs.EOF == false) {

				 // ERROR: Not supported in C#: OnErrorStatement

				rj = modRecordSet.getRS(ref "SELECT * FROM RecieptEx WHERE StockCode = '" + rs.Fields("StockCode").Value + "'");

				rt = modRecordSet.getRS(ref "SELECT Catalogue_StockItemID FROM Catalogue WHERE Catalogue_Barcode = '" + rs.Fields("StockCode").Value + "'");

				if (Information.IsDBNull(rt.Fields("Catalogue_StockItemID").Value) | rt.RecordCount == 0) {
				} else {
					modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_RecipeType = 2 WHERE StockItemID = " + rt.Fields("Catalogue_StockItemID").Value);
					if (rj.RecordCount > 0) {
						 // ERROR: Not supported in C#: OnErrorStatement

						while (rj.EOF == false) {
							if (prgUpdate.Value == 300) {
								prgUpdate.Value = 0;
							} else {
								prgUpdate.Value = prgUpdate.Value + 0.5;
							}
							rd = modRecordSet.getRS(ref "SELECT Catalogue_StockItemID FROM Catalogue WHERE Catalogue_Barcode = '" + rj.Fields("combStockCode").Value + "'");
							if (rd.RecordCount) {
								sqlInsert = "INSERT INTO RecipeStockitemLnk (RecipeStockitemLnk_RecipeID,RecipeStockitemLnk_StockitemID,RecipeStockitemLnk_Quantity)" + " Values ( " + rt.Fields("Catalogue_StockItemID").Value + "," + rd.Fields("Catalogue_StockItemID").Value + "," + rj.Fields("Quantity").Value + ")";
							}

							modRecordSet.cnnDB.Execute(sqlInsert);
							rj.moveNext();
							if (rj.EOF == false)
								rs.moveNext();
						}
					}
				}

				if (rs.EOF == true)
					break; // TODO: might not be correct. Was : Exit Do
				rs.moveNext();
			}
			prgUpdate.Value = 300;
			Interaction.MsgBox("Import Bill Of Material was completed succesfully", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "4POS Bill of Material Import");
			dooCleanUp();
			return;
			updateError:
			Interaction.MsgBox(Err().Description, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "4POS Bill of Material Import");
			dooCleanUp();
		}
		public void dooCleanUp()
		{
			modRecordSet.cnnDB.Execute("DROP TABLE RecieptEx");
		}

		private void Command2_Click()
		{
			bool ShowOpen = false;
			Button Command1 = new Button();
			TextBox Text1 = new TextBox();
			string strPath_DB = null;

			if (ShowOpen == true) {
				Text1.Text = strPath_DB;
				Command1.Enabled = true;
			} else {
				return;
			}

		}
		public bool ShowOpen1()
		{
			bool functionReturnValue = false;
			string strPath_DB1 = null;
			string Extention = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			var _with1 = cmdDlgOpen;
			//CancelError = True
			_with1.Title = "Upload Customer File";
			_with1.FileName = "";
			_with1.FilterIndex = 0;
			_with1.ShowDialog();
			//trPath_DB1 = .FileName

			if (!string.IsNullOrEmpty(strPath_DB1)) {
				txtFile.Text = strPath_DB1;
				functionReturnValue = true;
			} else {
				functionReturnValue = false;
			}
			return functionReturnValue;
			Extracter:


			if (MsgBoxResult.Cancel) {
				return functionReturnValue;
			}
			Interaction.MsgBox(Err().Description);
			return functionReturnValue;
		}

		private void Command3_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string grpDelete = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			//Catalogue baracorde
			int sgID = 0;

			if (modApplication.exUt_variable == 1) {
				if (ShowOpen1() == true) {
					System.Windows.Forms.Application.DoEvents();
					prgUpdate.Maximum = ReadLine(ref Strings.Trim(txtFile.Text));
					System.Windows.Forms.Application.DoEvents();
					if (ImportCSVHand(ref Strings.Trim(txtFile.Text)) == true) {
						//Me.lblHeading.Caption = "HandHeld StockTake: (Item Barcode, Item Quantity)"
						UpdateCatalogID();

						rs = modRecordSet.getRS(ref "SELECT StockGroupID FROM StockGroup WHERE StockGroup_Name = '" + st_Name + "'");
						sgID = rs.Fields("StockGroupID").Value;
						My.MyProject.Forms.frmStockTakeAdd.loadItem(ref sgID);

						rs = modRecordSet.getRS(ref "SELECT StockGroup_Name FROM StockGroup WHERE StockGroupID =" + sgID);
						if (Strings.UCase(Strings.Mid(rs.Fields("StockGroup_Name").Value, 1, 8)) == "HANDHELD") {
							grpDelete = Strings.Trim(rs.Fields("StockGroup_Name").Value);

							modRecordSet.cnnDB.Execute("DROP TABLE " + grpDelete);
							modRecordSet.cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='" + grpDelete + "'");
						}

						this.Close();
					}
				} else {
					return;
				}

			}

		}
		private void Command4_Click()
		{
			this.Close();
		}
		private bool ImportCSVHand(ref string strFilePath)
		{
			bool functionReturnValue = false;
			Scripting.FileSystemObject oFileSys = new Scripting.FileSystemObject();
			Scripting.TextStream oFile = default(Scripting.TextStream);
			string strCSV = null;
			string strFldName = null;
			//String of fields' name
			string strFV = null;
			//String of fields' values
			short iCount = 0;

			short x = 0;
			string strStr_1 = null;
			string strStr_2 = null;
			string Temp = null;
			string strIn = null;
			bool blEmpty = false;
			bool blTrue = false;

			string t_day = null;
			string t_Month = null;

			t_day = Strings.Trim(Convert.ToString(DateAndTime.Day(DateAndTime.Today)));
			t_Month = Strings.Trim(Convert.ToString(DateAndTime.Month(DateAndTime.Today)));

			System.Windows.Forms.Application.DoEvents();
			System.Windows.Forms.Application.DoEvents();

			ADODB.Recordset rs = default(ADODB.Recordset);

			if (Strings.Len(t_day) == 1)
				t_day = "0" + Strings.Trim(Convert.ToString(DateAndTime.Day(DateAndTime.Today)));
			if (Strings.Len(t_Month) == 1)
				t_Month = "0" + Strings.Trim(Convert.ToString(DateAndTime.Month(DateAndTime.Today)));

			 // ERROR: Not supported in C#: OnErrorStatement

			//Create A Table Name
			st_Name = "Handheld" + Strings.Trim(Convert.ToString(DateAndTime.Year(DateAndTime.Today))) + Strings.Trim(t_Month) + Strings.Trim(t_day);


			blTrue = false;
			blEmpty = true;

			dReceipt = false;

			prgUpdate.Value = 1;

			if (oFileSys.FileExists(strFilePath)) {


				oFile = oFileSys.OpenTextFile(strFilePath, Scripting.IOMode.ForReading, false, Scripting.Tristate.TristateUseDefault);
				System.Windows.Forms.Application.DoEvents();
				while (!oFile.AtEndOfLine) {
					System.Windows.Forms.Application.DoEvents();
					if (prgUpdate.Value == prgUpdate.Maximum) {
						System.Windows.Forms.Application.DoEvents();
						prgUpdate.Value = 0;
					} else {
						prgUpdate.Value = prgUpdate.Value + 1;
						System.Windows.Forms.Application.DoEvents();
					}

					blEmpty = false;
					strCSV = oFile.ReadLine;
					strFV = strCSV;
					System.Windows.Forms.Application.DoEvents();

					if (blTrue == false) {
						strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency";
						System.Windows.Forms.Application.DoEvents();
						modRecordSet.cnnDB.Execute("CREATE TABLE " + st_Name + " (" + strFldName + ")");
						blTrue = true;
						dReceipt = true;
					}

					if (strCSV != Constants.vbNullString) {
						//Repeat 2 Times
						//
						//                          strStr_1 = strCSV
						//                          x = Len(strCSV) - Len(Right(strCSV, Len(strCSV) - InStr(strCSV, ",")))
						//                          strStr_1 = mID$(strStr_1, 1, x - 1)
						//                          DoEvents
						//                          strStr_2 = Right(strCSV, Len(strCSV) - InStr(strCSV, ","))
						//                          temp = strStr_2

						strStr_1 = Strings.Split(strCSV, ",")[0];
						//                          If CCur(Split(strCSV, ",")(5)) = 0 Then
						//                                strStr_2 = CCur(Split(strCSV, ",")(3))
						//                          ElseIf CCur(Split(strCSV, ",")(3)) = 0 Then
						//                                strStr_2 = CCur(Split(strCSV, ",")(5))
						//                          Else
						//                            strStr_2 = CCur(Split(strCSV, ",")(3)) - CCur(Split(strCSV, ",")(5))
						//                          End If
						strStr_2 = Strings.Split(strCSV, ",")[5];
						Temp = strStr_2;
						System.Windows.Forms.Application.DoEvents();

						rs = modRecordSet.getRS(ref "SELECT * FROM " + st_Name + " WHERE Handheld_Barcode = '" + Strings.Trim(strStr_1) + "'");
						if (rs.RecordCount > 0) {
							strIn = "UPDATE " + st_Name + " SET Quantity = " + rs.Fields("Quantity").Value + Convert.ToDecimal(strStr_2) + " WHERE Handheld_Barcode = '" + Strings.Trim(strStr_1) + "'";
						} else {
							strIn = "INSERT INTO " + st_Name + " (Handheld_Barcode,Quantity) VALUES " + "('" + Strings.Trim(strStr_1) + "'," + Convert.ToDecimal(strStr_2) + ")";
						}

						System.Windows.Forms.Application.DoEvents();
						modRecordSet.cnnDB.Execute(strIn);
						System.Windows.Forms.Application.DoEvents();
					}
				}
				if (blEmpty == true) {
					Interaction.MsgBox("Your CSV file is empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Handheld StockTake");
					functionReturnValue = false;
					return functionReturnValue;

				}

				modRecordSet.cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('" + st_Name + "')");
				System.Windows.Forms.Application.DoEvents();
				functionReturnValue = true;
				return functionReturnValue;
			} else if (!oFileSys.FileExists(strFilePath)) {

				Interaction.MsgBox("CSV File does not exist", MsgBoxStyle.Information, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				functionReturnValue = false;
				return functionReturnValue;
			}
			ImportError:
			Interaction.MsgBox("Export aborted because " + Err().Description, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Handheld StockTake");
			if (dReceipt == true)
				modRecordSet.cnnDB.Execute("DROP TABLE " + st_Name);
			return functionReturnValue;
			 // ERROR: Not supported in C#: ResumeStatement

			return functionReturnValue;
		}
		public bool ImportCSVtoAccess(ref string strFilePath)
		{
			bool functionReturnValue = false;
			Scripting.FileSystemObject oFileSys = new Scripting.FileSystemObject();
			Scripting.TextStream oFile = default(Scripting.TextStream);
			string strCSV = null;
			string strFldName = null;
			//String of fields' name
			string strFV = null;
			//String of fields' values
			short iCount = 0;

			short x = 0;
			string strStr_1 = null;
			string strStr_2 = null;
			string strStr_3 = null;
			string strStr_4 = null;
			string Temp = null;
			string strIn = null;
			bool blEmpty = false;
			bool blTrue = false;

			short cCounter = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			System.Windows.Forms.Application.DoEvents();
			System.Windows.Forms.Application.DoEvents();
			cCounter = 0;
			blTrue = false;
			blEmpty = true;

			prgUpdate.Value = 1;

			dReceipt = false;

			if (oFileSys.FileExists(strFilePath)) {

				oFile = oFileSys.OpenTextFile(strFilePath, Scripting.IOMode.ForReading, false, Scripting.Tristate.TristateUseDefault);

				while (!oFile.AtEndOfLine) {
					cCounter = cCounter + 1;
					if (prgUpdate.Value == 300) {
						prgUpdate.Value = 0;
					} else {
						prgUpdate.Value = prgUpdate.Value + 0.1;
					}

					blEmpty = false;
					strCSV = oFile.ReadLine;
					strFV = strCSV;

					//strFldName = "StockCode Text," & _
					//'                  "combStockCode Text," & _
					//'                  "comStockDescription TEXT(120)," & _
					//'                  "Quantity Currency"
					strFldName = "StockCode Text," + "combStockCode Text," + "Quantity Currency";
					if (blTrue == false) {
						//strFldName = "StockCode Text,combStockCode Text,comStockDescription TEXT(120),Quantity Currency"
						strFldName = "StockCode Text,combStockCode Text,Quantity Currency";
						modRecordSet.cnnDB.Execute("CREATE TABLE RecieptEx (" + strFldName + ")");
						blTrue = true;
						dReceipt = true;
					}

					if (strCSV != Constants.vbNullString) {
						//Repeat 3 Times
						//
						strStr_1 = strCSV;
						x = Strings.Len(strCSV) - Strings.Len(Strings.Right(strCSV, Strings.Len(strCSV) - Strings.InStr(strCSV, ",")));
						strStr_1 = Strings.Mid(strStr_1, 1, x - 1);


						strStr_2 = Strings.Right(strCSV, Strings.Len(strCSV) - Strings.InStr(strCSV, ","));
						Temp = strStr_2;
						x = Strings.Len(strStr_2) - Strings.Len(Strings.Right(strStr_2, Strings.Len(strStr_2) - Strings.InStr(strStr_2, ",")));
						strStr_2 = Strings.Mid(strStr_2, 1, x - 1);

						strStr_3 = Strings.Right(Temp, Strings.Len(Temp) - Strings.InStr(Temp, ","));

						//temp = strStr_3
						//x = Len(strStr_3) - Len(Right(strStr_3, Len(strStr_3) - InStr(strStr_3, ",")))
						//strStr_3 = Mid$(strStr_3, 1, x - 1)

						//strStr_4 = Right(temp, Len(temp) - InStr(temp, ","))
						//strIn = "INSERT INTO RecieptEx (StockCode,combStockCode,comStockDescription,Quantity) VALUES " & _
						//'                  "(" & Val(strStr_1) & "," & Val(strStr_2) & ",'" & Replace(Trim(strStr_3), "'", "''") & "'," & CCur(strStr_4) & ")"

						strIn = "INSERT INTO RecieptEx (StockCode,combStockCode,Quantity) VALUES " + "(" + Conversion.Val(strStr_1) + "," + Conversion.Val(strStr_2) + "," + Convert.ToDecimal(strStr_3) + ")";
						modRecordSet.cnnDB.Execute(strIn);
					}
				}

				if (blEmpty == true) {
					Interaction.MsgBox("Your CSV file is empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "4POS Bill of Material Import");
					functionReturnValue = false;
					return functionReturnValue;
				}
				prgUpdate.Value = 300;
				functionReturnValue = true;
				return functionReturnValue;

			} else if (!oFileSys.FileExists(strFilePath)) {
				Interaction.MsgBox("CSV File does not exist", MsgBoxStyle.Information, "4POS Bill of Material Import");
				functionReturnValue = false;
				return functionReturnValue;
			}
			ImportError:

			if (cCounter == 0) {
				Interaction.MsgBox("Export Aborted Because " + Err().Description, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "4POS Bill of Material Import");
			} else {
				Interaction.MsgBox("Export Aborted At Record Number " + cCounter + " [" + strStr_1 + "," + strStr_2 + "," + strStr_3 + "] " + Err().Description, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "4POS Bill of Material Import");
			}

			if (dReceipt == true)
				dooCleanUp();
			return functionReturnValue;

		}
		public void UpdateCatalogID()
		{
			int a = 0;
			string strFldName = null;
			string sTempBC = null;
			string strIn = null;
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rID = default(ADODB.Recordset);

			//Set rID = getRS("SELECT * FROM " & st_Name)
			//Do While rID.EOF = False
			//        If prgUpdate.value = prgUpdate.Max Then
			//           prgUpdate.value = 0
			//        Else
			//           prgUpdate.value = prgUpdate.value + 1
			//        End If
			//    'rID("Handheld_Barcode") = 0
			//        rID("HandHeldID") = 0
			//        rID.update '"HandHeldID", 0
			// rID.moveNext
			//Loop

			strIn = "UPDATE " + st_Name + " SET HandHeldID = 0;";
			//strIn = "UPDATE " & st_Name & " SET HandHeldID = 0 WHERE Quantity > 0;"
			modRecordSet.cnnDB.Execute(strIn);

			rj = modRecordSet.getRS(ref "SELECT * FROM " + st_Name);
			while (rj.EOF == false) {
				if (prgUpdate.Value == prgUpdate.Maximum) {
					prgUpdate.Value = 0;
				} else {
					prgUpdate.Value = prgUpdate.Value + 1;
				}

				//Set rs = getRS("SELECT * FROM Catalogue WHERE Catalogue_Barcode = '" & rj("Handheld_Barcode") & "'")
				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, * FROM Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID WHERE (((Catalogue.Catalogue_Barcode)='" + rj.Fields("Handheld_Barcode").Value + "') AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));");
				if (rs.RecordCount > 0) {
					modRecordSet.cnnDB.Execute("UPDATE " + st_Name + " SET HandHeldID = " + rs.Fields("Catalogue_StockItemID").Value + ", Quantity = " + (rj.Fields("Quantity").Value * rs.Fields("Catalogue_Quantity").Value) + " WHERE Handheld_Barcode = '" + rj.Fields("Handheld_Barcode").Value + "'");
				} else {
					rs = modRecordSet.getRS(ref "SELECT * FROM StockItem WHERE (((StockItem.StockItem_QuickKey)='" + rj.Fields("Handheld_Barcode").Value + "') AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));");
					if (rs.RecordCount > 0) {
						modRecordSet.cnnDB.Execute("UPDATE " + st_Name + " SET HandHeldID = " + rs.Fields("StockItemID").Value + ", Quantity = " + (rj.Fields("Quantity").Value * 1) + " WHERE Handheld_Barcode = '" + rj.Fields("Handheld_Barcode").Value + "'");
					} else {
						sTempBC = rj.Fields("Handheld_Barcode").Value;
						while (Strings.Len(sTempBC) <= 13) {
							rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, * FROM Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID WHERE (((Catalogue.Catalogue_Barcode)='" + sTempBC + "') AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));");
							if (rs.RecordCount > 0) {
								System.Windows.Forms.Application.DoEvents();
								modRecordSet.cnnDB.Execute("UPDATE " + st_Name + " SET Handheld_Barcode = '" + sTempBC + "' WHERE Handheld_Barcode = '" + rj.Fields("Handheld_Barcode").Value + "'");
								System.Windows.Forms.Application.DoEvents();
								modRecordSet.cnnDB.Execute("UPDATE " + st_Name + " SET HandHeldID = " + rs.Fields("Catalogue_StockItemID").Value + ", Quantity = " + (rj.Fields("Quantity").Value * rs.Fields("Catalogue_Quantity").Value) + " WHERE Handheld_Barcode = '" + sTempBC + "'");
								System.Windows.Forms.Application.DoEvents();
								break; // TODO: might not be correct. Was : Exit Do
							}
							sTempBC = "0" + sTempBC;
						}
					}
				}


				rj.moveNext();
			}

			//chkDuplicate:
			strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency";
			modRecordSet.cnnDB.Execute("CREATE TABLE " + "Handheld777" + " (" + strFldName + ")");
			System.Windows.Forms.Application.DoEvents();

			rj = modRecordSet.getRS(ref "SELECT * FROM " + st_Name);
			while (rj.EOF == false) {

				if (Information.IsDBNull(rj.Fields("HandHeldID").Value)) {
					a = 1;
				} else if (rj.Fields("HandHeldID").Value == 0) {
					a = 1;
				} else {
					rs = modRecordSet.getRS(ref "SELECT * FROM Handheld777 WHERE HandHeldID=" + rj.Fields("HandHeldID").Value + ";");
					if (rs.RecordCount > 0) {
						strIn = "UPDATE Handheld777 SET Quantity = " + (rs.Fields("Quantity").Value + rj.Fields("Quantity").Value) + " WHERE HandHeldID=" + rj.Fields("HandHeldID").Value + ";";
					} else {
						strIn = "INSERT INTO Handheld777 (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + rj.Fields("HandHeldID").Value + ", '" + rj.Fields("Handheld_Barcode").Value + "', " + rj.Fields("Quantity").Value + ")";
					}
					modRecordSet.cnnDB.Execute(strIn);
				}

				rj.moveNext();
			}

			DeleteBlankID();

			modRecordSet.cnnDB.Execute("DELETE * FROM " + st_Name + ";");
			//strIn = "SELECT Handheld777.* INTO " & st_Name & " FROM Handheld777" '& ResolveTable(cmbTables.Text)
			modRecordSet.cnnDB.Execute("INSERT INTO " + st_Name + " SELECT * FROM Handheld777;");
			modRecordSet.cnnDB.Execute("DROP TABLE Handheld777;");
			//chkDuplicate:


			Interaction.MsgBox("File was extracted and imported succesfully", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
			//prgUpdate.value = 300

		}
		public void DeleteRecieptTable()
		{
			modRecordSet.cnnDB.Execute("DELETE * RecipeStockitemLnk");
		}
		public void loadItems(ref int id)
		{

			if (id == 1) {
				//Me.lblHeading.Caption = "HandHeld StockTake: (Item Barcode, Item Quantity)"
			} else {
				//Me.lblHeading.Caption = "BOM Item Number,Ingredients Item Number, Quantity"
			}

			//loadLanguage
			ShowDialog();
		}


		public short ReadLine(ref string fname)
		{
			short functionReturnValue = 0;
			Scripting.FileSystemObject oFSO = new Scripting.FileSystemObject();
			Scripting.TextStream oFSTR = default(Scripting.TextStream);
			int ret = 0;
			int lCtr = 0;
			if (oFSO.FileExists(fname)) {
				oFSTR = oFSO.OpenTextFile(fname);
				while (!oFSTR.AtEndOfStream) {
					lCtr = lCtr + 1;
					oFSTR.SkipLine();
				}
				functionReturnValue = lCtr;
				oFSTR.Close();
				oFSTR = null;
			}
			return functionReturnValue;
		}

		public void DeleteBlankID()
		{
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			//UPGRADE_NOTE: Val was upgraded to Val_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			string Val_Renamed = null;
			Scripting.FileSystemObject oFSO = new Scripting.FileSystemObject();

			//cnnDB.Execute "UPDATE " & st_Name & " SET HandHeldID = 0 WHERE Handheld_Barcode = " & vbNullString
			rj = modRecordSet.getRS(ref "SELECT * FROM " + st_Name + " WHERE HandHeldID = 0");

			short i = 0;
			short j = 0;
			if (rj.RecordCount > 0) {
				Interaction.MsgBox("CSV file has missing Barcodes, please verify them.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);

				//fill test array
				SaveArrayAsCSVFile.dChrom = new string[rj.RecordCount, 2];

				for (i = 0; i <= rj.RecordCount - 1; i++) {
					for (j = 0; j <= 1; j++) {
						if (j == 0) {
							SaveArrayAsCSVFile.dChrom[i, j] = rj.Fields("Handheld_Barcode").Value;
						} else {
							SaveArrayAsCSVFile.dChrom[i, j] = rj.Fields("Quantity").Value;
						}
					}
					rj.moveNext();
				}

				if (oFSO.FolderExists("C:\\temp\\")) {
				} else {
					oFSO.CreateFolder("C:\\temp\\");
				}
				SaveArrayAsCSVFile.SaveAsCSV(SaveArrayAsCSVFile.dChrom, "C:\\temp\\" + st_Name + "_Missing.csv");
				//App.Path & "\temp\" & st_Name & "_Missing.csv"

				//Set rs = getRS("SELECT Catalogue_StockItemID FROM Catalogue WHERE Catalogue_Barcode = '" & rj("Handheld_Barcode") & "'")
				//If rs.RecordCount > 0 Then cnnDB.Execute "UPDATE " & st_Name & " SET HandHeldID= " & rs("Catalogue_StockItemID") & " WHERE Handheld_Barcode = '" & rj("Handheld_Barcode") & "'"
				modRecordSet.cnnDB.Execute("DELETE from " + st_Name + " WHERE HandHeldID = 0");
				Interaction.MsgBox("CSV file has been as C:\\temp\\" + st_Name + "_Missing.csv");
			}
			//MsgBox "File was extracted and exported succesfully", vbApplicationModal + vbInformation + vbOKOnly, App.title

		}
	}
}
