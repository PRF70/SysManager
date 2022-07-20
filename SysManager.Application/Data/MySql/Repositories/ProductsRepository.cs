using Dapper;
using SysManager.Application.Contracts;
using SysManager.Application.Contracts.Products.Request;
using SysManager.Application.Data.MySql;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Helpers;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class ProductsRepository
    {
        private readonly MySqlContext _context;
        public ProductsRepository(MySqlContext context)
        {
            this._context = context;
        }
        public async Task<DefaultResponse> CreateAsync(ProductsEntity entity)
        {
            var _sql = @$"INSERT INTO product(id,productcode, name, productTypeId, categoryId, unityId, costPrice, percentage,
                       price, active) VALUE('{entity.Id}','{entity.ProductCode}', '{entity.Name}', '{entity.ProductTypeId}',
                                            '{entity.CategoryId}','{entity.UnityId}',{entity.CostPrice},{entity.Percentage},
                                             {entity.Price},{entity.Active})";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.ExecuteAsync(_sql);
                if (result > 0)
                    return new DefaultResponse(entity.Id.ToString(), "Produto criado com sucesso", false);
            }

            return new DefaultResponse(entity.Id.ToString(), "Falha ao tentar cadastrar um produto", true);
        }
        public async Task<DefaultResponse> UpdateAsync(ProductsEntity entity)
        {
            var _sql = @$"UPDATE product set productcode= '{entity.ProductCode}',name = '{entity.Name}', productTypeId='{entity.ProductTypeId}',
                         categoryId='{entity.CategoryId}', unityId='{entity.UnityId}', costPrice={entity.CostPrice}, percentage={entity.Percentage},
                         price={entity.Price},active = {entity.Active} WHERE id = '{entity.Id}'";
                                     
            using (var cnx = _context.Connection())
            {
                var result = await cnx.ExecuteAsync(_sql);
                if (result > 0)
                    return new DefaultResponse(entity.Id.ToString(), "Produto alterado com sucesso", false);
            }

            return new DefaultResponse(entity.Id.ToString(), "Falha ao tentar alterar um produto", true);
        }
        public async Task<ProductsEntity> GetByIdAsync(Guid id)
        {
            var _sql = @$"SELECT id,productcode, name, productTypeId, categoryId, unityId, costPrice, percentage,
                          price, active from product WHERE id = '{id}' limit 1";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryFirstOrDefaultAsync<ProductsEntity>(_sql);
                return result;
            }
        }

        public async Task<ProductsEntity> GetByProductCodeAsync(string productcode)
        {
            var _sql = @$"SELECT id,productcode, name, productTypeId, categoryId, unityId, costPrice, percentage,
                       price, active from product WHERE productcode = '{productcode}' limit 1";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryFirstOrDefaultAsync<ProductsEntity>(_sql);
                return result;
            }
        }

        public async Task<ProductsEntity> GetByNameAsync(string name)
        {
            var _sql = $"SELECT productcode, name, active from product WHERE name = '{name}' limit 1";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryFirstOrDefaultAsync<ProductsEntity>(_sql);
                return result;
            }
        }
        public async Task<DefaultResponse> DeleteByIdAsync(Guid id)
        {
            var _sql = $"DELETE from product WHERE id = '{id}'";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.ExecuteAsync(_sql);
                if (result > 0)
                    return new DefaultResponse(id.ToString(), "Produto excluido com sucesso", false);
            }

            return new DefaultResponse(id.ToString(), "Falha ao tentar excluir um produto", true);
        }
        public async Task<PaginationResponse<ProductsEntity>> GetByFilterAsync(ProductsGetFilterRequest filter)
        {
            var _sql = new StringBuilder("select * from product where 1=1");
            var _where = new StringBuilder();

            if (!string.IsNullOrEmpty(filter.Name))
                _where.Append($" AND name like '%{filter.Name}%'");

            if (!string.IsNullOrEmpty(filter.ProductTypeId))
                _where.Append(" AND productTypeId = '" + filter.ProductTypeId + "'");

            if (!string.IsNullOrEmpty(filter.UnityId))
                _where.Append(" AND unityId = '" + filter.UnityId + "'");

            if (!string.IsNullOrEmpty(filter.CategoryId))
                _where.Append(" AND categoryId = '" + filter.CategoryId + "'");

            if (filter.Active.ToLower() != "todos")
            {
                string _activeFilter = "";

                if (filter.Active.ToLower() == "ativos")
                    _activeFilter = " AND active = true";
                else if (filter.Active.ToLower() == "inativos")
                    _activeFilter = " AND active = false";

                _where.Append(_activeFilter);
            }
            _sql.Append(_where);

            if (filter.page > 0 && filter.pageSize > 0)
                _sql.Append($" limit {filter.pageSize * (filter.page - 1)}, {filter.pageSize}");
            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryAsync<ProductsEntity>(_sql.ToString());
                var resultCount = await cnx.QueryAsync<int>("select count(*) as count from product where 1=1" + _where.ToString());
                return new PaginationResponse<ProductsEntity>
                {
                    _page = filter.page,
                    _pageSize = filter.pageSize,
                    _total = resultCount.FirstOrDefault()
,
                    Items = result.ToArray()
                };
            }
        }
    }
}
