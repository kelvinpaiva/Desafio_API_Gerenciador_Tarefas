# Desafio_API_Gerenciador_Tarefas
Desafio Técnico - Dev .Net Sr. | EclipseWorks

############################################ Explicação simples do Projeto ############################################
Projeto desenvolvido no Visual Studio 2022. 
API feita em .NET Core 6.0.
Banco de dados (PostgreSQL) hospadado em núvem particular (caso queira o script eu posso passar).
Os acessos do banco estão no AppSettings.json.
Utilizado testes em projeto a parte.
Docker já configurado na solution, só mudar o execute do VS (Visual Studio) para Docker e seja feliz :D 

############################################ Para o PO Responsável ####################################################
Poderia detalhar melhor sobre os comentários? Teria algo mais que queira acrescer? Como edição e exclusão deles?
Sobre as tarefas, acha interessante ter uma data de cadastro dela? Assim teríamos uma base de quando cada uma foi solicitada.
E os projetos, teriam somente o título? Acha que talvez uma data de Finalização do mesmo, não seria interessante?

############################################# Pontos para futuras implementações ######################################
Para futuras melhorias, vejo que poderia acrescer:

# Endpoint que retornam somente os comentários de determinada tarefa.
# Endpoint para um relatório que retorne os Projetos (em ordem alfabética) com suas Tarefas (em ordem cronológica de cadastro)
e comentários, em ordem de cronológica de cadastro.
# Endpoint de alteração e exclusão de comentário.
