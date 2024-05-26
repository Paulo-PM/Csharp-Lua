function operacao(a, b)
    return multiply(a, b)
end

function add(a, b)
    return a + b
end

function subtract(a, b)
    return a - b
end

function multiply(a, b)
    return a * b
end

function divide(a, b)
    if b ~= 0 then
        return a / b
    else
        return nil, "divisão por zero"
    end
end

function quadrado(a, b)
    return a*(a-b) + b*(a-b)
end