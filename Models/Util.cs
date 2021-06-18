using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MRO.Models
{

    public enum TipoGrupo
    {
        [Display(Name = "Estoque Ideal Calculado")]
        EstoqueIdealCalculado = 1,
        [Display(Name = "Estoque Ideal Fixo")]
        EstoqueIdealFixo = 2,
        [Display(Name = "Estoque Ideal Zerado")]
        EstoqueIdealZerado = 3
    }

    public enum Periculosidade
    {
        [Display(Name = "Danger")]
        Danger= 1,
        [Display(Name = "Warning")]
        Warning = 2,
        [Display(Name = "No Danger")]
        NoDanger= 3
    }

    public enum Natureza
    {
        [Display(Name = "Aeronáutico")]
        Aeronautico = 1,
        [Display(Name = "Não Aeronáutico Aprovado para Uso")]
        NaoAeronauticoAprovadoUso= 2,
        [Display(Name = "Não Aeronáutico")]
        NaoAeronautico = 3
    }

    public enum SituacaoCadastroPn
    {
        [Display(Name = "Pré Cadastro")]
        PreCadastro = 1,
        [Display(Name = "Cadastrado")]
        CadastradoAMM = 2,
        [Display(Name = "Vinculado Totvs")]
        VinculadoTotvs = 3
    }

    public enum Ativo
    {
        [Display(Name = "Ativo")]
        Ativo = 1,
        [Display(Name = "Inativo")]
        Inativo = 0,
    }

    public enum CriterioPeriodicidade
    {
        [Display(Name = "Inicial")]
        Inicial= 1,
        [Display(Name = "Repetitiva")]
        Repetitiva = 2,
        [Display(Name = "Controlado por Componente")]
        ControladoComponente = 3,
    }


}
