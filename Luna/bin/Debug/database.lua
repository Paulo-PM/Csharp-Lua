--Apenas a função "operacao" é lida pelo programa, mas vc pode chamar as outras
--dentro dela veja o exemplo

function Operacao(a, b)
    return Divisao(a, b)
end


-- As funções abaixo são apenas uma coleção para serem usadas em Operacao
-- O retorno obedece a seguinte ordem, [Mensagem de erro ou aviso],[Valor da operação],[Mensagem da operação]
function Soma(a, b)
    return "", a + b , SMS(a.." + "..b.." = ")
end

function Subtracao(a, b)
    return "", a - b , SMS(a.." - "..b.." = ")
end

function Multiplicacao(a, b)
    return "", a * b , SMS(a.." x "..b.." = ")
end

function Divisao(a, b)
    if b ~= 0 then
        return "", a / b , SMS(a.." / "..b.." = ")
    else
        return SMS("Erro divisão por zero"), 0
    end
end

function ProdutoNotavel(a, b)
    return SMS("PMR Softworks©"), a*(a-b) + b*(a-b) , SMS("Produto notavel de "..a.." e "..b.." = ")
end


--##################### [Funções do Sistema. Não mexer] ###########################################
-- A função abaixo transforma o texto em uma sequencia de escape hexadecimal, 
-- isso é necessario para evitar que caracteres acentuados apareçam como "?"
function SMS(texto)
    local encode = string.gsub(texto,"(.)",function (x) return string.format("\\x%02X",string.byte(x)) end)
    return encode
end