using NLua;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luna
{
    public partial class Form1 : Form
    {
        private FileSystemWatcher watcher = null;
        private string LuaFileName = "database.lua";

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
            TB_Log.SelectionColor = Color.DodgerBlue;
            TB_Log.AppendText("PMR Softworks© 2014-2024\r\n\r\n");
            TB_Log.SelectionColor = Color.Black;
            TB_Log.AppendText("Este programa utiliza a linguagem de programação C-sharp e Lua, " +
                              "as operações podem ser modificadas no script [database.lua]\r\n");
            GetMoonIntegrityFile();

            //Monitora o arquivo .lua
            watcher = new FileSystemWatcher();
            watcher.Path = Application.StartupPath;
            watcher.Filter = LuaFileName;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.EnableRaisingEvents = true;

        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                this.Invoke(new Action(() => GetMoonIntegrityFile()));
            }
            else if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                this.Invoke(new Action(() => GetMoonIntegrityFile()));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica se os valores são válidos e chama a função
            if (float.TryParse(TB_num1.Text, out float valorA) && float.TryParse(TB_num2.Text, out float valorB))
            {     
                GetMoonData(valorA, valorB);
            }
            else
            {
                // Os valores inválidos?, exibe uma mensagem de erro
                if (TB_num1.Text == "Maya" && TB_num2.Text == "Ikusaba")
                {
                    TB_Log.SelectionColor = Color.Red;
                    TB_Log.AppendText("♥♥♥♥♥\r\n");
                    TB_Log.SelectionColor = Color.Black;
                    pictureBox1.Image = Properties.Resources._01;
                }
                else
                {
                    TB_Log.SelectionColor = Color.Red;
                    TB_Log.AppendText("Digite valores numéricos válidos nos campos.\r\n");
                    TB_Log.SelectionColor = Color.Black;
                    pictureBox1.Image = Properties.Resources._05;
                }
            }
        }

        private void GetMoonIntegrityFile()
        {
            using (Lua luaFile = new Lua())
            {             
                if (File.Exists(LuaFileName))
                {
                    TB_Log.SelectionColor = Color.Green;
                    TB_Log.AppendText("Arquivo [" + LuaFileName + "] encontrado!\r\n");
                    TB_Log.SelectionColor = Color.Black;

                    button1.ForeColor = Color.Black;
                    button1.Text = "Calcular";
                    button1.BackColor = ColorTranslator.FromHtml("#0078D7");
                    pictureBox1.Image = Properties.Resources._04;
                }
                else
                {
                    TB_Log.SelectionColor = Color.Red;
                    TB_Log.AppendText("ERRO: Arquivo [" + LuaFileName + "] Não encontrado!\r\n");
                    TB_Log.SelectionColor = Color.Black;

                    button1.ForeColor = Color.White;
                    button1.Text = "Erro!";
                    button1.BackColor = Color.DarkRed;
                    pictureBox1.Image = Properties.Resources._03;
                }
            }
        }

        private void GetMoonData(float A, float B)
        {
            using (Lua lua = new Lua())
            {
                try
                {
                    // Verifica se o arquivo existe antes de carregá-lo
                    if (File.Exists(LuaFileName))
                    {
                        lua.DoFile(LuaFileName);

                        // Uso da Função
                        var LF_result = lua.GetFunction("Operacao").Call(A, B);

                        // Conversão do texto
                        string LF_log = System.Text.RegularExpressions.Regex.Unescape((string)LF_result[0]);
                        LF_log = Encoding.UTF8.GetString(Encoding.Default.GetBytes(LF_log));

                        float LF_valor = (float)(double)LF_result[1];

                        string LF_operacao = System.Text.RegularExpressions.Regex.Unescape((string)LF_result[2]);
                        LF_operacao = Encoding.UTF8.GetString(Encoding.Default.GetBytes(LF_operacao));

                        // Print
                        if (LF_log.Length>1)
                        {
                            TB_Log.SelectionColor = Color.IndianRed;
                            TB_Log.AppendText($"OBS: {LF_log}\r\n");
                        }
                        TB_Log.SelectionColor = Color.Black;
                        TB_Log.AppendText($"Resultado: {LF_operacao}{LF_valor}\r\n");
                        
                        pictureBox1.Image = Properties.Resources._02;
                    }
                    else
                    {
                        GetMoonIntegrityFile();
                    }
                }
                catch (Exception ex)
                {
                    // Outras exceções aqui
                    TB_Log.SelectionColor = Color.Purple;
                    TB_Log.AppendText("Erro: [" + ex.Message + "]\r\n");
                    TB_Log.SelectionColor = Color.Black;
                    pictureBox1.Image = Properties.Resources._03;
                }
            }
        }
    }
}
