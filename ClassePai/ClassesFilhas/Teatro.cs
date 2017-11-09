using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Teatro:Evento
    {
        public string [] Elenco { get; set; }
        public string Diretor { get; set; }
        public Teatro()
        {
            
        }
        public Teatro(string Titulo, string Local, int Lotacao, string Duracao, int Classificacao, DateTime Data, string[] Elenco, string Diretor)
        {
            this.Titulo = Titulo;
            this.Local = Local;
            this.Lotacao = Lotacao;
            this.Duracao = Duracao;
            this.Classificacao = Classificacao;
            this.Data = Data;
            this.Elenco = Elenco;
            this.Diretor = Diretor;
        }

        public override bool Cadastrar(){
        
        bool resultado = false;
        StreamWriter arquivo = null;

        try{
            arquivo = new StreamWriter("teatro.csv",true);
            
            string laco = "";

            for(int i = 0; i < Elenco.Length; i++){
               laco+=Elenco[i]+",";
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
            Diretor
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
            ler = new StreamReader("teatro.csv",Encoding.Default);

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
            ler = new StreamReader("teatro.csv",Encoding.Default);

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