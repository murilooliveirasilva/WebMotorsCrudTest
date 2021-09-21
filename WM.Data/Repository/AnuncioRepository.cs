using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Bussiness.Interfaces;
using WM.Bussiness.Models;

namespace WM.Data.Repository
{

    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly IDbConnection _dbConnection;


        public AnuncioRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            //_dbSession = dbSession;
        }

        public int Add(AnuncioModel anuncioModel)
        {
            string insertQuery = @"INSERT INTO teste_webmotors.tb_anunciowebmotors(Marca, Modelo, Versao, Ano, Quilometragem, Observacao) 
            VALUES (@Marca, @Modelo, @Versao, @Ano, @Quilometragem, @Observacao)";

            var result = _dbConnection.Execute(insertQuery, new
            {
                anuncioModel.Marca,
                anuncioModel.Modelo,
                anuncioModel.Versao,
                anuncioModel.Ano,
                anuncioModel.Quilometragem,
                anuncioModel.Observacao,
                
            });
            return result;
        }

        public int Delete(AnuncioModel anuncioModel)
        {
            string deleteQuery = @"DELETE FROM teste_webmotors.tb_anunciowebmotors WHERE id = @Id";

            var result = _dbConnection.Execute(deleteQuery, new
            {
                anuncioModel.ID
            });
            return result;
        }

        public void Dispose()
        {
        }

        public AnuncioModel Findby(int id)
        {
            return _dbConnection.Query<AnuncioModel>("SELECT * FROM tb_AnuncioWebmotors where id = @id", new { @id = id }).FirstOrDefault();
        }

        public List<AnuncioModel> getAnuncios()
        {
            return _dbConnection.Query<AnuncioModel>("SELECT * FROM tb_AnuncioWebmotors").ToList();
        }

        public int Update(AnuncioModel anuncioModel)
        {
            string updateQuery = @"Update teste_webmotors.tb_anunciowebmotors 
            SET Marca = @Marca , Modelo = @Modelo, Versao = @Versao, Ano = @Ano, Quilometragem = @Quilometragem, Observacao=@Observacao
            WHERE Id = @Id";

            var result = _dbConnection.Execute(updateQuery, new
            {
                anuncioModel.Marca,
                anuncioModel.Modelo,
                anuncioModel.Versao,
                anuncioModel.Ano,
                anuncioModel.Quilometragem,
                anuncioModel.Observacao,
                anuncioModel.ID

            });
            return result;


        }
    }
}
