// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let numberOfInstructions = 2;

function AddInstruction(){
    const index = numberOfInstructions;
    numberOfInstructions++;

    let labelElement = document.createElement('label');
    labelElement.setAttribute("for", `Instructions_${index}__Description`);
    labelElement.innerText = 'Description';

    let inputElement = document.createElement('input');
    inputElement.setAttribute("type", "text");
    inputElement.setAttribute("id", `Instructions_${index}__Description`);
    inputElement.setAttribute("name", `Instructions[${index}].Description`);
    inputElement.setAttribute("class", "form-control");

    let spanElement = document.createElement('span');
    spanElement.setAttribute("class", "field-validation-valid");
    spanElement.setAttribute("data-valmsg-for", `Instructions[${index}].Description`);
    spanElement.setAttribute("data-valmsg-replace", "true");

    let formGroupElement = document.createElement('div');
    formGroupElement.setAttribute("class", "form-group row col-md-12");
    formGroupElement.appendChild(labelElement);
    formGroupElement.appendChild(inputElement);

    let instructions = document.getElementById('instructions');
    instructions.appendChild(formGroupElement);
}

function AddIngredient(){
    alert('add ingredient');
}
