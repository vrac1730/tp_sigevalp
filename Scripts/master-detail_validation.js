function EqualsZero(c) {
    return c == 0 ? "Seleccione un producto" : "";
}
function LessThanZero(c) {
    return c < 0 ? "Este campo no puede ser negativo" : "";
}
function IsEmpty(c) {
    return c == "" ? "Este campo es requerido" : "";
}
function EmptyOrMinor(c) {
    return c == "" ? IsEmpty(c) : LessThanZero(c);
}
function IsSymbol(c) {
} 
function EmptyOrMinorOrSymbol(c) {
    return c == "" ? IsEmpty(c) : c < 0 ? LessThanZero(c) : IsSymbol(c);
}
function GetId(c) {
    return c.substr(4, c.length);
}
export { EqualsZero, IsEmpty, LessThanZero, EmptyOrMinor, GetId };