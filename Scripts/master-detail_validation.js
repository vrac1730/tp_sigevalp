export function EqualsZero(c) {
    return c == 0 ? "Este campo es requerido" : "";
}
export function LessThanZero(c) {
    return c < 0 ? "Este campo no puede ser negativo" : "";
}
export function IsEmpty(c) {
    return c == "" ? "Este campo es requerido" : "";
}
export function EmptyOrMinor(c) {
    return c == "" ? IsEmpty(c) : LessThanZero(c);
}
export function EmptyOrMinorOrZero(c) {
    return c == "" ? IsEmpty(c) : c < 0 ? LessThanZero(c) : EqualsZero(c);
}
export function EqualsZeroBool(c) {
    return c == 0 ? true : false;
}
export function LessThanZeroBool(c) {
    return c < 0 ? true : false;
}
export function IsEmptyBool(c) {
    return c == "" ? true : false;
}
export function EmptyOrMinorBool(c) {
    return c == "" ? IsEmptyBool(c) : LessThanZeroBool(c);
}
export function EmptyOrMinorOrZeroBool(c) {
    return c == "" ? IsEmptyBool(c) : c < 0 ? LessThanZeroBool(c) : EqualsZeroBool(c);
}
export function IsSymbol(c) {
} 
export function EmptyOrMinorOrSymbol(c) {
    return c == "" ? IsEmpty(c) : c < 0 ? LessThanZero(c) : IsSymbol(c);
}
export function GetId(c) {
    return c.substr(4, c.length);
}
export function createButton(name, tdopccion, funct) {//[name, funct]
    let button = document.createElement("input");
    button.value = name;
    button.type = "button";
    button.onclick = funct;
    button.className = "btn btn-default";
    tdopccion.appendChild(button);
}
export function createTd(value, tr) {//[value]
    let td = document.createElement("td");
    td.innerHTML = value;
    tr.appendChild(td);
}
export function createInput(id, model, prop, value, div) {//[prop, value]
    let input = document.createElement("input");
    createInputId(input, id, model, prop);
    input.value = value;
    input.type = "hidden";
    div.appendChild(input);
}
export function createInputId(input, id, model, prop) {//[input] [prop] misma longitud
    input.id = model + "[" + id + "]." + prop;
    input.name = input.id;
}