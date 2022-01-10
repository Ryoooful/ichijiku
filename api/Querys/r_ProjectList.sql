-- DECLARE @project_id AS INT = -1
SELECT
    t_project_id.project_id,
    t_project_id.project_cd,
    t_project_id.project_title,
    t_project_id.project_description,
    t_project_id.project_state_id,
    m_project_state_id.project_state,
    t_project_id.customer_id,
    m_customer_id.customer_name,
    t_project_id.model_cd,
    t_project_id.hide,
    t_product_id.product_id AS 'ProductModel.product_id',
    t_product_id.product_cd AS 'ProductModel.product_cd',
    t_product_id.prodcut_state_id AS 'ProductModel.prodcut_state_id',
    m_prodcut_state_id.prodcut_state AS 'ProductModel.prodcut_state',
    t_product_id.product_name AS 'ProductModel.product_name',
    t_product_id.customer_number AS 'ProductModel.customer_number',
    t_product_id.customer_part_name AS 'ProductModel.customer_part_name'
FROM
    t_project_id
    LEFT OUTER JOIN t_product_id ON t_project_id.project_id = t_product_id.project_id
    LEFT OUTER JOIN m_customer_id ON t_project_id.customer_id = m_customer_id.customer_id
    LEFT OUTER JOIN m_project_state_id ON t_project_id.project_state_id = m_project_state_id.project_state_id
    LEFT OUTER JOIN m_prodcut_state_id ON t_product_id.prodcut_state_id = m_prodcut_state_id.prodcut_state_id
WHERE
    t_project_id.project_id = CASE
        @project_id
        WHEN -1 THEN t_project_id.project_id
        ELSE @project_id
    END
FOR JSON PATH;