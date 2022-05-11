Imports FAndradeTI.Util
Imports FAndradeTI.Util.FileSystem
Imports FAndradeTI.Util.WinForms
Imports Mp3FileHandler.BusinessRules
Imports Mp3FileHandler.BusinessRules.Model

Public Class FrmMain
    Inherits System.Windows.Forms.Form

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsLabel As ToolStripStatusLabel
    Private jsonFile As String
    Private mng As FileRenamerManager

    Const playlistPath As String = ":\Playlists"
    Friend WithEvents chkSaveCommand As CheckBox
    Const playlistExtension As String = "*.m3u"

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        WinReg.SubKey = "SOFTWARE\\" + Application.CompanyName + "\\" + Application.ProductName

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnRenomear As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents pnMain As Panel
    Friend WithEvents chkAbreviar As CheckBox
    Friend WithEvents txtSubstituir As TextBox
    Friend WithEvents chkRemover As CheckBox
    Friend WithEvents btnAbrir As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPrefixo As TextBox
    Friend WithEvents txtExtensao As TextBox
    Friend WithEvents btnPesquisar As Button
    Friend WithEvents txtCaminho As TextBox
    Friend WithEvents txtSubstPor As TextBox
    Friend WithEvents labelPor As Label
    Friend WithEvents chkPrefixo As CheckBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnRenomearLote As Button
    Friend WithEvents btnTratarMusica As Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.btnRenomear = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnTratarMusica = New System.Windows.Forms.Button()
        Me.pnMain = New System.Windows.Forms.Panel()
        Me.chkSaveCommand = New System.Windows.Forms.CheckBox()
        Me.txtSubstPor = New System.Windows.Forms.TextBox()
        Me.labelPor = New System.Windows.Forms.Label()
        Me.chkPrefixo = New System.Windows.Forms.CheckBox()
        Me.chkAbreviar = New System.Windows.Forms.CheckBox()
        Me.txtSubstituir = New System.Windows.Forms.TextBox()
        Me.chkRemover = New System.Windows.Forms.CheckBox()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPrefixo = New System.Windows.Forms.TextBox()
        Me.txtExtensao = New System.Windows.Forms.TextBox()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        Me.txtCaminho = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnRenomearLote = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnMain.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRenomear
        '
        Me.btnRenomear.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnRenomear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRenomear.Image = CType(resources.GetObject("btnRenomear.Image"), System.Drawing.Image)
        Me.btnRenomear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRenomear.Location = New System.Drawing.Point(12, 138)
        Me.btnRenomear.Name = "btnRenomear"
        Me.btnRenomear.Size = New System.Drawing.Size(232, 62)
        Me.btnRenomear.TabIndex = 12
        Me.btnRenomear.Text = "&Renomear"
        Me.btnRenomear.UseVisualStyleBackColor = False
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'btnTratarMusica
        '
        Me.btnTratarMusica.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnTratarMusica.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTratarMusica.Image = CType(resources.GetObject("btnTratarMusica.Image"), System.Drawing.Image)
        Me.btnTratarMusica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTratarMusica.Location = New System.Drawing.Point(298, 138)
        Me.btnTratarMusica.Name = "btnTratarMusica"
        Me.btnTratarMusica.Size = New System.Drawing.Size(257, 62)
        Me.btnTratarMusica.TabIndex = 13
        Me.btnTratarMusica.Text = "&Tratar Música sem Título"
        Me.btnTratarMusica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTratarMusica.UseVisualStyleBackColor = False
        '
        'pnMain
        '
        Me.pnMain.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnMain.Controls.Add(Me.chkSaveCommand)
        Me.pnMain.Controls.Add(Me.txtSubstPor)
        Me.pnMain.Controls.Add(Me.labelPor)
        Me.pnMain.Controls.Add(Me.chkPrefixo)
        Me.pnMain.Controls.Add(Me.chkAbreviar)
        Me.pnMain.Controls.Add(Me.txtSubstituir)
        Me.pnMain.Controls.Add(Me.chkRemover)
        Me.pnMain.Controls.Add(Me.btnAbrir)
        Me.pnMain.Controls.Add(Me.Label2)
        Me.pnMain.Controls.Add(Me.Label1)
        Me.pnMain.Controls.Add(Me.txtPrefixo)
        Me.pnMain.Controls.Add(Me.txtExtensao)
        Me.pnMain.Controls.Add(Me.btnPesquisar)
        Me.pnMain.Controls.Add(Me.txtCaminho)
        Me.pnMain.Location = New System.Drawing.Point(12, 12)
        Me.pnMain.Name = "pnMain"
        Me.pnMain.Size = New System.Drawing.Size(836, 120)
        Me.pnMain.TabIndex = 12
        '
        'chkSaveCommand
        '
        Me.chkSaveCommand.AutoSize = True
        Me.chkSaveCommand.Checked = True
        Me.chkSaveCommand.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSaveCommand.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSaveCommand.Location = New System.Drawing.Point(688, 20)
        Me.chkSaveCommand.Name = "chkSaveCommand"
        Me.chkSaveCommand.Size = New System.Drawing.Size(145, 24)
        Me.chkSaveCommand.TabIndex = 11
        Me.chkSaveCommand.Text = "Salvar Comando"
        Me.chkSaveCommand.UseVisualStyleBackColor = True
        '
        'txtSubstPor
        '
        Me.txtSubstPor.Enabled = False
        Me.txtSubstPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubstPor.Location = New System.Drawing.Point(444, 83)
        Me.txtSubstPor.Name = "txtSubstPor"
        Me.txtSubstPor.Size = New System.Drawing.Size(224, 26)
        Me.txtSubstPor.TabIndex = 8
        '
        'labelPor
        '
        Me.labelPor.AutoSize = True
        Me.labelPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPor.Location = New System.Drawing.Point(406, 86)
        Me.labelPor.Name = "labelPor"
        Me.labelPor.Size = New System.Drawing.Size(32, 20)
        Me.labelPor.TabIndex = 23
        Me.labelPor.Text = "por"
        '
        'chkPrefixo
        '
        Me.chkPrefixo.AutoSize = True
        Me.chkPrefixo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrefixo.Location = New System.Drawing.Point(19, 83)
        Me.chkPrefixo.Name = "chkPrefixo"
        Me.chkPrefixo.Size = New System.Drawing.Size(80, 24)
        Me.chkPrefixo.TabIndex = 9
        Me.chkPrefixo.Text = "Prefixo:"
        Me.chkPrefixo.UseVisualStyleBackColor = True
        '
        'chkAbreviar
        '
        Me.chkAbreviar.AutoSize = True
        Me.chkAbreviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAbreviar.Location = New System.Drawing.Point(239, 51)
        Me.chkAbreviar.Name = "chkAbreviar"
        Me.chkAbreviar.Size = New System.Drawing.Size(86, 24)
        Me.chkAbreviar.TabIndex = 5
        Me.chkAbreviar.Text = "Abreviar"
        Me.chkAbreviar.UseVisualStyleBackColor = True
        '
        'txtSubstituir
        '
        Me.txtSubstituir.Enabled = False
        Me.txtSubstituir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubstituir.Location = New System.Drawing.Point(444, 49)
        Me.txtSubstituir.Name = "txtSubstituir"
        Me.txtSubstituir.Size = New System.Drawing.Size(224, 26)
        Me.txtSubstituir.TabIndex = 7
        '
        'chkRemover
        '
        Me.chkRemover.AutoSize = True
        Me.chkRemover.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRemover.Location = New System.Drawing.Point(343, 51)
        Me.chkRemover.Name = "chkRemover"
        Me.chkRemover.Size = New System.Drawing.Size(95, 24)
        Me.chkRemover.TabIndex = 6
        Me.chkRemover.Text = "Substituir"
        Me.chkRemover.UseVisualStyleBackColor = True
        '
        'btnAbrir
        '
        Me.btnAbrir.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbrir.Image = CType(resources.GetObject("btnAbrir.Image"), System.Drawing.Image)
        Me.btnAbrir.Location = New System.Drawing.Point(637, 16)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(32, 28)
        Me.btnAbrir.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Extensão:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Caminho:"
        '
        'txtPrefixo
        '
        Me.txtPrefixo.Enabled = False
        Me.txtPrefixo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrefixo.Location = New System.Drawing.Point(120, 81)
        Me.txtPrefixo.Name = "txtPrefixo"
        Me.txtPrefixo.Size = New System.Drawing.Size(205, 26)
        Me.txtPrefixo.TabIndex = 10
        '
        'txtExtensao
        '
        Me.txtExtensao.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExtensao.Location = New System.Drawing.Point(120, 49)
        Me.txtExtensao.Name = "txtExtensao"
        Me.txtExtensao.ReadOnly = True
        Me.txtExtensao.Size = New System.Drawing.Size(93, 26)
        Me.txtExtensao.TabIndex = 4
        Me.txtExtensao.Text = "*.mp3"
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPesquisar.Image = CType(resources.GetObject("btnPesquisar.Image"), System.Drawing.Image)
        Me.btnPesquisar.Location = New System.Drawing.Point(599, 16)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(32, 28)
        Me.btnPesquisar.TabIndex = 2
        '
        'txtCaminho
        '
        Me.txtCaminho.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaminho.Location = New System.Drawing.Point(120, 17)
        Me.txtCaminho.Name = "txtCaminho"
        Me.txtCaminho.ReadOnly = True
        Me.txtCaminho.Size = New System.Drawing.Size(473, 26)
        Me.txtCaminho.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(13, 206)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.Size = New System.Drawing.Size(835, 354)
        Me.DataGridView1.TabIndex = 15
        '
        'btnRenomearLote
        '
        Me.btnRenomearLote.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnRenomearLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRenomearLote.Image = CType(resources.GetObject("btnRenomearLote.Image"), System.Drawing.Image)
        Me.btnRenomearLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRenomearLote.Location = New System.Drawing.Point(610, 138)
        Me.btnRenomearLote.Name = "btnRenomearLote"
        Me.btnRenomearLote.Size = New System.Drawing.Size(238, 62)
        Me.btnRenomearLote.TabIndex = 14
        Me.btnRenomearLote.Text = "&Renomear Lote"
        Me.btnRenomearLote.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 576)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(863, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsLabel
        '
        Me.tsLabel.Name = "tsLabel"
        Me.tsLabel.Size = New System.Drawing.Size(133, 17)
        Me.tsLabel.Text = "ToolStripStatusLabel1"
        '
        'FrmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(863, 598)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnRenomearLote)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnTratarMusica)
        Me.Controls.Add(Me.btnRenomear)
        Me.Controls.Add(Me.pnMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "File Renamer"
        Me.pnMain.ResumeLayout(False)
        Me.pnMain.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmFileRename_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = AppInfo.GetFullTitle()

        tsLabel.Text = ""

        txtCaminho.Text = WinReg.Read("InputPath")

        While String.IsNullOrEmpty(txtCaminho.Text)
            txtCaminho.Text = FS.GetFolder(txtCaminho.Text, "Selecione a pasta de músicas...")
        End While

        Dim ToolTip1 As New System.Windows.Forms.ToolTip()
        ToolTip1.SetToolTip(Me.btnAbrir, "Abrir pasta")

        Dim ToolTip2 As New System.Windows.Forms.ToolTip()
        ToolTip2.SetToolTip(Me.btnPesquisar, "Pesquisar pasta")



    End Sub

    Private Function VerificarCampos() As Boolean

        Dim ret As Boolean = True

        If (Not FS.FolderExists(txtCaminho.Text)) Then
            MsgBox("Caminho não existe!", MsgBoxStyle.Exclamation, Me.Text)
            Cursor.Show()
            pnMain.Enabled = True
            ret = False
        ElseIf chkRemover.Checked And txtSubstituir.Text.Trim() = "" Then
            MsgBox("Texto a remover em branco!", MsgBoxStyle.Exclamation, Me.Text)
            Cursor.Show()
            pnMain.Enabled = True
            ret = False
        End If

        Return ret

    End Function

    Private Sub btnRenomearLote_Click(sender As Object, e As EventArgs) Handles btnRenomearLote.Click

        Me.Cursor = Cursors.WaitCursor
        pnMain.Enabled = False
        tsLabel.Text = String.Empty

        For Each row As DataGridViewRow In DataGridView1.Rows

            Dim dados As Mp3FileInfo = GetGridData(row)

            Dim processed As Integer = mng.ProcessFile(dados)

            If processed <> 0 Then tsLabel.Text += $"({row.Index}) como {processed} processados / "

            dados.Extensao = playlistExtension

            mng.ProcessPlaylist(txtCaminho.Text.Substring(0, 1) + playlistPath, dados)

        Next

        pnMain.Enabled = True
        Me.Cursor = Cursors.Default
        tsLabel.Text = " Processamento em lote finalizado!"

    End Sub


    Private Sub btnRenomear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenomear.Click

        Me.Cursor = Cursors.WaitCursor
        pnMain.Enabled = False
        tsLabel.Text = String.Empty

        If (Not VerificarCampos()) Then
            Me.Cursor = Cursors.Default
            pnMain.Enabled = True
            Exit Sub
        End If

        WinReg.Write("InputPath", txtCaminho.Text)

        Dim dados As Mp3FileInfo = GetFormData()

        Dim processed As Integer = mng.ProcessFile(dados)

        If processed <> 0 And chkSaveCommand.Checked Then

            mng.SaveCommand(dados)

            MontarGrid()

        End If

        dados.Extensao = playlistExtension
        mng.ProcessPlaylist(txtCaminho.Text.Substring(0, 1) + playlistPath, dados)

        pnMain.Enabled = True
        Me.Cursor = Cursors.Default
        tsLabel.Text = processed & " arquivos renomeados!"
    End Sub

    Private Function GetFormData() As Mp3FileInfo

        Dim dados As New Mp3FileInfo()

        dados.Abreviar = chkAbreviar.Checked.ToString()
        dados.Caminho = txtCaminho.Text
        dados.Extensao = txtExtensao.Text
        dados.Prefixo = txtPrefixo.Text
        dados.Substituir = txtSubstituir.Text
        dados.Substpor = txtSubstPor.Text

        Return dados

    End Function

    Private Function GetGridData(row As DataGridViewRow) As Mp3FileInfo

        Dim dados As New Mp3FileInfo()

        dados.Abreviar = row.Cells(5).Value
        dados.Caminho = row.Cells(0).Value.ToString()
        dados.Extensao = row.Cells(1).Value.ToString()
        dados.Prefixo = row.Cells(2).Value.ToString()
        dados.Substituir = row.Cells(3).Value.ToString()
        dados.Substpor = row.Cells(4).Value.ToString()

        Return dados

    End Function

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click

        txtCaminho.Text = FS.GetFolder(txtCaminho.Text, "Selecione a pasta de músicas.")

        FrmMain_Shown(sender, e)

        'FolderBrowserDialog1.SelectedPath = txtCaminho.Text

        'Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()

        'If (result = DialogResult.OK) Then
        '    txtCaminho.Text = FolderBrowserDialog1.SelectedPath
        'End If

    End Sub


    Private Sub FolderBrowserDialog1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles FolderBrowserDialog1.Disposed
        MsgBox("!@")
    End Sub



    Private Sub MontarGrid()

        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.DataSource = mng.ListCommand

        If mng.ListCommand Is Nothing Then
            Return
        End If

        DataGridView1.AutoGenerateColumns = True
        DataGridView1.Columns(0).Width = 330
        DataGridView1.Columns(1).Width = 70
        DataGridView1.Columns(2).Width = 80
        DataGridView1.Columns(3).Width = 150
        DataGridView1.Columns(4).Width = 80
        DataGridView1.Columns(5).Width = 60
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Refresh()

    End Sub


    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click

        ProcManager.RunExplorer(txtCaminho.Text)

    End Sub

    Private Sub chkSubstituir_CheckedChanged(sender As Object, e As EventArgs)

        If chkRemover.Checked Then
            txtSubstituir.Enabled = True
        Else
            txtSubstituir.Enabled = False
            txtSubstituir.Text = ""
        End If

    End Sub

    Private Sub btnTratarMusica_Click(sender As Object, e As EventArgs) Handles btnTratarMusica.Click

        Me.Cursor = Cursors.WaitCursor
        pnMain.Enabled = False

        Dim caminho As String = txtCaminho.Text

        If (Not FS.FolderExists(caminho)) Then
            MsgBox("Caminho não existe!", MsgBoxStyle.Exclamation, Me.Text)
            Cursor.Show()
            Exit Sub
        End If

        WinReg.Write("InputPath", txtCaminho.Text)

        Dim mt As New MusicTool()

        Dim processed As Integer = mt.TratarInfo(caminho)

        pnMain.Enabled = True
        Me.Cursor = Cursors.Default

        tsLabel.Text = processed & " músicas tratadas!"

        MsgBox(tsLabel.Text, MsgBoxStyle.Information, Me.Text)


    End Sub

    Private Sub chkRemover_CheckedChanged(sender As Object, e As EventArgs) Handles chkRemover.CheckedChanged
        Dim cbx As CheckBox = sender

        If Not cbx.Checked Then
            txtSubstituir.Text = ""
            txtSubstituir.Enabled = False
            txtSubstPor.Text = ""
            txtSubstPor.Enabled = False
        Else
            txtSubstituir.Enabled = True
            txtSubstPor.Enabled = True
        End If
    End Sub

    Private Sub chkPrefixo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrefixo.CheckedChanged
        Dim cbx As CheckBox = sender

        If Not cbx.Checked Then
            txtPrefixo.Text = ""
            txtPrefixo.Enabled = False
        Else
            txtPrefixo.Enabled = True
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        Dim result As Integer = MessageBox.Show("Deseja excluir o comando selecionado?", "Exclusão de Comando", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            mng.Delete(e.RowIndex)

            If mng.ListCommand Is Nothing Then
                Return
            End If
            MontarGrid()

        End If

    End Sub

    Private Sub FrmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        jsonFile = FS.PathCombine(txtCaminho.Text, Application.ProductName + ".json")

        mng = New FileRenamerManager(jsonFile)

        If Not String.IsNullOrEmpty(mng.Msg) Then
            MsgBox(mng.Msg, MsgBoxStyle.Exclamation, Me.Text)
            Return
        End If

        MontarGrid()
    End Sub


End Class
