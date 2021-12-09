using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CadastroDeVeiculos.Domain.Validations.Resource
{
    public enum Message
    {
        [Description("{0} não encontrada.")]
        NotFound,

        [Description("{0} não é válido.")]
        RequestInvalid,

        [Description("{0} é obrigatório.")]
        Required,

        [Description("Adicione {0} para cadastrar o {1}.")]
        EmptList,

        [Description("Selecione um item da lista {0}")]
        SelectOneItem,

        [Description("Este {0} já existe na base de dados.")]
        Exist,

        [Description("Campo {0} não permite mais que {1} caracteres.")]
        MoreExpected,

        [Description("O {0} deve ser maior que {1}.")]
        PriceExpected,

        [Description("Objeto não configurado")]
        ErrorNotConfigured

    }
}
