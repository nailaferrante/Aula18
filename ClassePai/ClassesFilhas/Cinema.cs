using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Cinema:Evento
    {
        public DateTime [] Sessao { get; set; }
        public string Genero { get; set; }
        public Cinema()
        {
            
        }
        public Cinema(string Titulo, string Local, int Lotacao, string Duracao, int Classificacao, DateTime Data, DateTime[] Sessao, string Genero)
        {
            this.Titulo = Titulo;
            this.Local = Local;
            this.Lotacao = Lotacao;
            this.Duracao = Duracao;
            this.Classificacao = Classificacao;
            this.Data = Data;
            this.Sessao = Sessao;
            this.Genero = Genero;
        }

        public override bool Cadastrar(){
        
        bool resultado = false;
        StreamWriter arquivo = null;

        try{
            arquivo = new StreamWriter("cinema.csv",true);
            
            string laco = "";

            for(int i = 0; i < Sessao.Length; i++){
               laco+=Sessao[i]+",";
            }
            string lacofinal = laco.Substring(0,laco.Length-1);

            arquivo.WriteLine(
            lacofinal+";"+
            Titulo+";"+ 
            Local+";"+ 
            Lotacao+";"+ 
            Duracao+";"+ 
            Classificacao+";"+ 
            Data+";"+ 
            Genero
            );
            resultado = true;
        }
        catch(Exception ex)
            {
                throw new Exception("Erro ao tentar gravar o arquivo. "+ex.Message);
            }
        finally
            {
                arquivo.Close();
            }
        return resultado;
        }
         public override string Pesquisar(string Titulo)
        {
            string resultado = "Titulo não encontrado!";

            StreamReader ler = null;

            try{
            ler = new StreamReader("cinema.csv",Encoding.Default);

            string linha ="";

            while((linha=ler.ReadLine())!=null)
            {
                string[] dados = linha.Split(';');
                if(dados[0]==Titulo)
                {
                    resultado = linha;
                    break;
                }
            }
            }
            catch(Exception ex){
                resultado = "Erro ao tentar ler o arquivo! "+ex.Message;
            }
            finally{
                ler.Close();
            }
            return resultado;
        }
    public override string Pesquisar(DateTime Data)
        {
            string resultado = "Data não encontrado!";

            StreamReader ler = null;

            try{
            ler = new StreamReader("cinema.csv",Encoding.Default);

            string linha ="";

            while((linha=ler.ReadLine())!=null)
            {
                string[] dados = linha.Split(';');
                if(dados[6]==Data.ToString())
                {
                    resultado = linha;
                    break;
                }
            }
            }
            catch(Exception ex){
                resultado = "Erro ao tentar ler o arquivo! "+ex.Message;
            }
            finally{
                ler.Close();
            }
            return resultado;
        }
    }
}