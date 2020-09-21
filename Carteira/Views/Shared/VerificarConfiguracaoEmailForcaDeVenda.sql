select * from CONFIGURACAOEMAIL
select * from CONFSISVENDA

-- CONFSISVENDA: Email do Gerente Responsável por Liberar o Pedido
-- Coluna: ConfVDiasAtrasoBloqPedido (Email)

-- CONFIGURACAOEMAIL: Dados de quem vai enviar o E-mail
-- CONFEMAILENDERECO (email)
-- CONFEMAILSENHA (senha do email)

-- Arquivo AppSettings.json
-- Dominio: mail.cooperoestesc.com.br
-- Porta: 587

USE [Cooperoeste]
GO

INSERT INTO [dbo].[CONFIGURACAOEMAIL] ([ConfEmailCod], [ConfEmailNome], [ConfEmailEndereco], [ConfEmailAutenticacao]
           ,[ConfEmailPorta] ,[ConfEmailHost] ,[ConfEmailUsuario], [ConfEmailSenha], [ConfProxyServerHost], [ConfProxyServerPort]
           ,[ConfProxyUser] ,[ConfProxyPassword] ,[ConfEmailPastaAnexos] ,[ConfEmailRecebeSoNaoLidas] ,[ConfEmailSSL] ,[ConfEmailFinalidade])
     VALUES (5, 'Solicitação Aprovação' , 'fulano@cooperoestesc.com.br', 0, 587, 'mail.cooperoestesc.com.br', 'fulano@cooperoestesc.com.br', 'SenhaDoFulano', '', 0, '', '', '', 0, 0, 3)
GO