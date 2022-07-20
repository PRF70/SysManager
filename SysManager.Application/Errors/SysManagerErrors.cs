using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SysManager.Application.Errors
{
    public enum SysManagerErrors
    {
        #region user
        [Description("Necessário informar a propriedade (Username)")]
        User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty,
        [Description("Necessário informar a propriedade (Email)")]
        User_Post_BadRequest_Email_Cannot_Be_Null_Or_Empty,
        [Description("Necessário informar a propriedade (Password)")]
        User_Post_BadRequest_Password_Cannot_Be_Null_Or_Empty,
        [Description("Já existe usuário com esse e-mail cadastrado!")]
        User_Post_BadRequest_Email_Cannot_Be_Duplicated,
        [Description("Usuário ou e-mail inválido ou inexistente")]
        User_Put_BadRequest_User_Not_Found,
        #endregion

        #region Unity
        [Description("É necessário informar o nome da unidade de medida")]
        Unity_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar se a unidade é ativa ou inativa")]
        Unity_Post_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,
        [Description("Já existe uma unidade de medida com esse nome")]
        Unity_Post_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("É necessário informar o id da unidade de medida")]
        Unity_Put_BadRequest_Id_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar o nome da unidade de medida")]
        Unity_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar se a unidade é ativa ou inativa")]
        Unity_Put_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,
        [Description("Já existe uma unidade de medida com esse nome")]
        Unity_Put_BadRequest_Name_Cannot_Be_Duplicated,
        [Description("Unidade de medida inválida ou inexistente")]
        Unity_Put_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("Unidade de medida inválida ou inexistente")]
        Unity_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("Id da unidade de medida é necessária")]
        Unity_Get_BadRequest_Id_Is_Invalid_Or_Inexistent,
        [Description("Nome da unidade de medida inexistente ou inválida")]
        Unity_Get_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("Unidade de medida inexistente ou inválida")]
        Unity_Get_BadRequest_Active_Cannot_Be_Empty,
        [Description("Unidade de medida inexistente ou inválida")]
        Unity_Get_BadRequest_Page_More_Than_Zero,
        [Description("Unidade de medida inexistente ou inválida")]
        Unity_Get_BadRequest_pageSize_More_Than_Zero,
        #endregion

        #region Category
        [Description("É necessário informar o nome da categoria")]
        Category_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar se a categoria é ativa ou inativa")]
        Category_Post_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,
        [Description("Já existe uma categoria com esse nome")]
        Category_Post_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("É necessário informar o id da categoria")]
        Category_Put_BadRequest_Id_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar o nome da categoria")]
        Category_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar se a categoria é ativa ou inativa")]
        Category_Put_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,
        [Description("Já existe uma categoria com esse nome")]
        Category_Put_BadRequest_Name_Cannot_Be_Duplicated,
        [Description("Categoria inválida ou inexistente")]
        Category_Put_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("Categoria inválida ou inexistente")]
        Category_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("Id da categoria é necessária")]
        Category_Get_BadRequest_Id_Is_Invalid_Or_Inexistent,
        [Description("Nome da categoria inexistente ou inválida")]
        Category_Get_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("Categoria inexistente ou inválida")]
        Category_Get_BadRequest_Active_Cannot_Be_Empty,
        [Description("Categoria inexistente ou inválida")]
        Category_Get_BadRequest_Page_More_Than_Zero,
        [Description("Categoria inexistente ou inválida")]
        Category_Get_BadRequest_pageSize_More_Than_Zero,
        #endregion

        #region ProductType
        [Description("É necessário informar o nome do tipo do produto")]
        ProductType_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar se o tipo do produto é ativa ou inativa")]
        ProductType_Post_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,
        [Description("Já existe um tipo do produto com esse nome")]
        ProductType_Post_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("É necessário informar o id do tipo do produto")]
        ProductType_Put_BadRequest_Id_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar o nome do tipo do produto")]
        ProductType_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar se o tipo do produto é ativa ou inativa")]
        ProductType_Put_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,
        [Description("Já existe um tipo do produto com esse nome")]
        ProductType_Put_BadRequest_Name_Cannot_Be_Duplicated,
        [Description("Tipo do produto inválida ou inexistente")]
        ProductType_Put_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("Tipo do produto inválida ou inexistente")]
        ProductType_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("Id do tipo do produto é necessária")]
        ProductType_Get_BadRequest_Id_Is_Invalid_Or_Inexistent,            
        [Description("Nome do tipo do produto inexistente ou inválida")]
        ProductType_Get_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("Tipo do produto inexistente ou inválida")]
        ProductType_Get_BadRequest_Active_Cannot_Be_Empty,
        [Description("Tipo do produto inexistente ou inválida")]
        ProductType_Get_BadRequest_Page_More_Than_Zero,
        [Description("Tipo do produto inexistente ou inválida")]
        ProductType_Get_BadRequest_pageSize_More_Than_Zero,
        #endregion

        #region Products
        [Description("Código do Produto é necessário")]
        Products_Post_BadRequest_ProductCode_Cannot_Be_Null_Or_Empty,
        [Description("Código do Produto já existente")]
        Products_Post_BadRequest_ProductCode_Cannot_Be_Duplicated,
        [Description("É necessário informar o nome do produto")]
        Products_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar se o produto é ativa ou inativa")]
        Products_Post_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,
        [Description("Já existe um produto com esse nome")]
        Products_Post_BadRequest_Name_Cannot_Be_Duplicated,
        [Description("A unidade medida é necessária")]
        Products_Post_BadRequest_UnityId_Cannot_Be_Null_Or_Empty,
        [Description("A categoria é necessária")]
        Products_Post_BadRequest_CategoryId_Cannot_Be_Null_Or_Empty,
        [Description("O tipo de produto é necessário")]
        Products_Post_BadRequest_ProductTypeId_Cannot_Be_Null_Or_Empty,
        [Description("Categoria não encontrada")]
        Products_Post_BadRequest_CategoryId_Cannot_Be_Found,
        [Description("Unidade de medida não encontrada")] 
        Products_Post_BadRequest_UnityId_Cannot_Be_Found,
        [Description("Tipo de produto não encontrada")]
        Products_Post_BadRequest_ProductTypeId_Cannot_Be_Found,
        [Description("Valor de custo deve ser maior que zero")]
        Products_Post_BadRequest_CostPrice_Must_Be_Greater_Than_Zero,
        [Description("Valor do produto deve corresponder ao cálculo do custo mais porcentagem")]
        Product_Post_BadRequest_Price_Must_Be_Exact,

        [Description("É necessário informar o id do produto")]
        Products_Put_BadRequest_Id_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar o nome do produto")]
        Products_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar se o produto é ativa ou inativa")]
        Products_Put_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,
        [Description("Já existe um produto com esse nome")]
        Products_Put_BadRequest_Name_Cannot_Be_Duplicated,
        [Description("Id do Produto inválida ou inexistente")]
        Products_Put_BadRequest_Id_Is_Invalid_Or_Inexistent,
        [Description("Código do Produto inválida ou inexistente")]
        Products_Put_BadRequest_ProductCode_Is_Invalid_Or_Inexistent,
        [Description("A unidade medida é necessária")]
        Products_Put_BadRequest_UnityId_Cannot_Be_Null_Or_Empty,
        [Description("A categoria é necessária")]
        Products_Put_BadRequest_CategoryId_Cannot_Be_Null_Or_Empty,
        [Description("O tipo de produto é necessário")]
        Products_Put_BadRequest_ProductTypeId_Cannot_Be_Null_Or_Empty,
        [Description("Categoria não encontrada")]
        Products_Put_BadRequest_CategoryId_Cannot_Be_Found,
        [Description("Unidade de medida não encontrada")]
        Products_Put_BadRequest_UnityId_Cannot_Be_Found,
        [Description("Tipo de produto não encontrada")]
        Products_Put_BadRequest_ProductTypeId_Cannot_Be_Found,
        [Description("Valor de custo deve ser maior que zero")]
        Products_Put_BadRequest_CostPrice_Must_Be_Greater_Than_Zero,
        [Description("Valor do produto deve corresponder ao cálculo do custo mais porcentagem")]
        Products_Put_BadRequest_Price_Must_Be_Exact,
        [Description("Código do produto não pode ser duplicado")]
        Products_Put_BadRequest_ProductCode_Cannot_Be_Duplicated,


        [Description("Produto inválido ou inexistente")]
        Products_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("Id do produto é necessária")]
        Products_Get_BadRequest_Id_Is_Invalid_Or_Inexistent,
        [Description("Nome do Produto não pode ser vazio ou Nulo")]
        Products_Get_BadRequest_Name_Cannot_Be_Null_Or_Empty,
        [Description("Active do Produto não pode ser vazio")]
        Products_Get_BadRequest_Active_Cannot_Be_Empty,
        [Description("Page tem que ser maior que zero")]
        Products_Get_BadRequest_Page_More_Than_Zero,
        [Description("Tamanho da Págin tem que ser maior que zero")]
        Products_Get_BadRequest_pageSize_More_Than_Zero,
        #endregion

    }
}
