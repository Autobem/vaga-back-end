using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        private DateTime _Criacao;

        [Key]
        public int Id { get; set; }
        public DateTime Criacao
        {
            get { return _Criacao; }
            set { _Criacao = (value==null? DateTime.UtcNow:value); }
        }
        public DateTime? Atualizacao { get; set; }
    }
}