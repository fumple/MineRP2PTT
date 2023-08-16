using Microsoft.Win32;
using NAudio.CoreAudioApi;
using PTT.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTT
{
    public partial class Form1 : Form
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private static IntPtr _hookID = IntPtr.Zero;

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private bool shiftDown = false, ctrlDown = false, altDown = false, held = false;
        private IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (key != null && device != null && shortcutTextBox != null && !shortcutTextBox.ContainsFocus)
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    var vKey = (Keys)vkCode;
                    if (vKey == Keys.LShiftKey || vKey == Keys.RShiftKey) shiftDown = true;
                    else if (vKey == Keys.LControlKey || vKey == Keys.RControlKey) ctrlDown = true;
                    else if (vKey == Keys.LMenu || vKey == Keys.RMenu) altDown = true;
                    else if (vKey == key && modifiers.HasFlag(Keys.Shift) == shiftDown && modifiers.HasFlag(Keys.Control) == ctrlDown && modifiers.HasFlag(Keys.Alt) == altDown)
                    {
                        setMute(false);
                        held = true;
                    }
                }
                else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    var vKey = (Keys)vkCode;
                    if (vKey == Keys.LShiftKey || vKey == Keys.RShiftKey) {
                        shiftDown = false;
                        if(held && modifiers.HasFlag(Keys.Shift)) {
                            held = false; setMute(true);
                        }
                    }
                    else if (vKey == Keys.LControlKey || vKey == Keys.RControlKey)
                    {
                        ctrlDown = false;
                        if (held && modifiers.HasFlag(Keys.Control)) {
                            held = false; setMute(true);
                        }
                    }
                    else if (vKey == Keys.LMenu || vKey == Keys.RMenu)
                    {
                        altDown = false;
                        if (held && modifiers.HasFlag(Keys.Alt)) {
                            held = false; setMute(true);
                        }
                    }
                    else if (held && vKey == key && modifiers.HasFlag(Keys.Shift) == shiftDown && modifiers.HasFlag(Keys.Control) == ctrlDown && modifiers.HasFlag(Keys.Alt) == altDown)
                    {
                        setMute(true);
                        held = false;
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        MMDevice device;
        RegistryKey storage;
        public Form1()
        {
            InitializeComponent();
            loadDefaultDevice();
            _hookID = SetHook(HookCallback);
            storage = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Fumple\MineRP2_PTT");
            if (storage.GetValue("KeyCombo") != null)
            {
                key = (Keys)Enum.Parse(typeof(Keys), (string)storage.GetValue("KeyCombo"));
                modifiers = (Keys)Enum.Parse(typeof(Keys), (string)storage.GetValue("KeyComboModifiers"));
                shortcutTextBox.Text = modifiers.ToString() + ", " + key.ToString();
            }
        }
        private void loadDefaultDevice()
        {
            var enumerator = new MMDeviceEnumerator();
            device = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Communications);
            labelCurrentDevice.Text = device.FriendlyName;
            setMute(key != null);
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            loadDefaultDevice();
        }


        private void setMute(bool mute)
        {
            device.AudioEndpointVolume.Mute = mute;
            muteCheckbox.Checked = mute;
            muteCheckbox.Text = mute ? Resources.muted : Resources.unmuted;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            setMute(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            storage.SetValue("KeyCombo", key);
            storage.SetValue("KeyComboModifiers", modifiers);
        }

        private void muteCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            setMute(muteCheckbox.Checked);
        }

        private Keys key;
        private Keys modifiers;
        private void shortcutTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            /*if (key != null)
            {
                shift = false; ctrl = false; alt = false;
            }
            if (e.KeyData == Keys.ShiftKey || e.KeyData == Keys.Control || e.KeyData == Keys.Menu) key = null;
            if (e.KeyData == Keys.ShiftKey) shift = true;
            else if (e.KeyData == Keys.Control) ctrl = true;
            else if (e.KeyData == Keys.Menu) alt = true;
            else
            {
                key = e.KeyData;
                setMute(true);
                /*ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                localSettings.Values["kb_shift"] = shift;
                localSettings.Values["kb_ctrl"] = ctrl;
                localSettings.Values["kb_alt"] = alt;
                localSettings.Values["kb_key"] = ((int?)key);*/
            //}
            //shortcutTextBox.Text = (shift ? "Shift+" : "") + (ctrl ? "Ctrl+" : "") + (alt ? "Alt+" : "") + (key != null ? key.ToString() : "");*/
            key = e.KeyCode;
            modifiers = e.Modifiers;
            shortcutTextBox.Text = modifiers.ToString() + ", " + key.ToString();
            setMute(true);
        }
    }
}
