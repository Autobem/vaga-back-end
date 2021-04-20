using System;

namespace Api.Domain.Models
{
    public class PessoaModel
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        
        private DateTime _Atualizacao;
        public DateTime Atualizacao
        {
            get { return _Atualizacao; }
            set { _Atualizacao = (value==null? DateTime.UtcNow : value); }
        }
        
        private string _Documento;
        public string Documento
        {
            get { return _Documento; }
            set { _Documento = value; }
        }
        
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        
        private string _Cidade;
        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }
        
        private string _Uf;
        public string Uf
        {
            get { return _Uf; }
            set { _Uf = value; }
        }
        
    }
}