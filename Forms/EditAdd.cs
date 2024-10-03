using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DiscordStatusRotationUI.Forms
{
    public partial class EditAdd : Form
    {
        private string _status;
        private readonly ListBox _listBoxStatus;
        private readonly bool _isEdit;
        private readonly Action _saveAction;
        public EditAdd(ListBox statusListBox, Action saveAction)
        : this(statusListBox, string.Empty, false, saveAction)
        {
        }

        public EditAdd(ListBox statusListBox, string status, bool isEdit, Action saveAction)
        {
            _status = status;
            _listBoxStatus = statusListBox;
            _isEdit = isEdit;
            _saveAction = saveAction;

            InitializeComponent();
            if (_isEdit && !string.IsNullOrEmpty(_status))
            {
                InitializeEditForm();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (_isEdit)
            {
                EditStatus();
            }
            else
            {
                AddStatus();
            }
            _saveAction?.Invoke();
            CloseForm();
        }

        private void CloseForm()
        {
            this.Close();
        }

        private void InitializeEditForm()
        {
            LabelTitle.Text = "Edit";
            TextboxStatus.Text = _status;
        }

        private void AddStatus()
        {
            if (!string.IsNullOrWhiteSpace(TextboxStatus.Text))
            {
                var index = _listBoxStatus.Items.Add(TextboxStatus.Text);
                SelectIndex(index);
            }
        }
        private void SelectIndex(int index)
        {
            if (_listBoxStatus.Items.Count > 0 && index >= 0 && index < _listBoxStatus.Items.Count)
            {
                _listBoxStatus.SelectedIndex = index;
            }
        }
        private void EditStatus()
        {
            int selectedIndex = _listBoxStatus.SelectedIndex;
            if (selectedIndex != -1 && !string.IsNullOrWhiteSpace(TextboxStatus.Text))
            {
                _listBoxStatus.Items[selectedIndex] = TextboxStatus.Text;
                SelectIndex(selectedIndex);
            }
        }
    }
}
