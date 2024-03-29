﻿using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.shared
{
    public interface ICadastravel
    {
        public abstract void Inserir();
        public abstract void Editar();
        public abstract void Excluir();

        public virtual void AdicionarItens() { }

        public virtual void AtualizarItens() { }

        public virtual void Filtrar() { }

        public virtual void PDF() { }

        public abstract UserControl ObtemListagem();

        public abstract ConfiguracaoToolboxBase ObtemConfiguracaoToolbox();
    }
}
