using Projeto.Domain.Aggregates.Usuarios.Contracts.Repositories;
using Projeto.Domain.Aggregates.Usuarios.Contracts.Services;
using Projeto.Domain.Aggregates.Usuarios.CrossCutting;
using Projeto.Domain.Aggregates.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Aggregates.Usuarios.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMD5Cryptography cryptography;

        public UsuarioDomainService(IUsuarioRepository usuarioRepository, IMD5Cryptography cryptography)
        {
            this.usuarioRepository = usuarioRepository;
            this.cryptography = cryptography;
        }

        public void Create(Usuario obj)
        {
            //verificar se o email informado ja está cadastrado na base
            if (usuarioRepository.Count(u => u.Email.Equals(obj.Email)) > 0) 
                throw new Exception("Email já cadastrado"); 

            //criptografando a senha
            obj.Senha = cryptography.Encrypt(obj.Senha);
            usuarioRepository.Create(obj);
        }

        public void Delete(Usuario obj)
        {
            usuarioRepository.Delete(obj);
        }

        public List<Usuario> GetAll()
        {
            return usuarioRepository.GetAll();
        }

        public Usuario GetByEmail(string email)
        {
            return usuarioRepository
                .Get(u => u.Email.Equals(email));
        }

        public Usuario GetByEmailAndSenha(string email, string senha)
        {
            senha = cryptography.Encrypt(senha);

            return usuarioRepository
                .Get(u => u.Email.Equals(email)
                       && u.Senha.Equals(senha));
        }

        public Usuario GetById(int id)
        {
            return usuarioRepository.GetById(id);
        }

        public void Update(Usuario obj)
        {
            usuarioRepository.Update(obj);
        }
    }
}
