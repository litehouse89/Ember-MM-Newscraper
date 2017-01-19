﻿' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################

Imports addon.kodi.Addon
Imports EmberAPI
Imports NLog

Public Class frmSettingsPanel

#Region "Fields"

    Shared logger As Logger = LogManager.GetCurrentClassLogger()

#End Region 'Fields

#Region "Events"

    Public Event SettingsChanged()
    Public Event StateChanged(ByVal bEnabled As Boolean)

#End Region 'Events

#Region "Constructors"

    Public Sub New()
        InitializeComponent()
        SetUp()
    End Sub

#End Region 'Constructors

#Region "Methods"

    Private Sub chkEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkEnabled.CheckedChanged
        RaiseEvent StateChanged(chkEnabled.Checked)
    End Sub

    Private Sub dgvWatchList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWatchList.CellEndEdit
        If e.ColumnIndex = 2 AndAlso
            Not String.IsNullOrEmpty(dgvWatchList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString) AndAlso
            Not dgvWatchList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.EndsWith("/") Then
            dgvWatchList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Concat(dgvWatchList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, "/")
        End If
    End Sub

    Sub SetUp()
        chkEnabled.Text = Master.eLang.GetString(774, "Enabled")
    End Sub

#End Region 'Methods

End Class