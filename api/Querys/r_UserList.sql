-- DECLARE @user_cd AS VARCHAR(50) = '',
-- @dept_cd AS VARCHAR(10) = ''
SELECT
    m_user_cd.user_cd,
    m_user_cd.[user_name],
    m_user_cd.mail,
    m_user_cd.dept_cd,
    m_user_cd.admin,
    m_user_cd.accept,
    m_user_cd.hide,
    m_dept_cd.dept_name,
    m_user_cd.[user_name] + char(9) + '[' + m_dept_cd.dept_name + ']' AS display_name
FROM
    m_user_cd
    LEFT OUTER JOIN m_dept_cd ON m_user_cd.dept_cd = m_dept_cd.dept_cd
WHERE
    m_user_cd.user_cd = CASE
        @user_cd
        WHEN '' THEN m_user_cd.user_cd
        ELSE @user_cd
    END
    AND m_user_cd.dept_cd = CASE
        @dept_cd
        WHEN '' THEN m_user_cd.dept_cd
        ELSE @dept_cd
    END
FOR JSON PATH;