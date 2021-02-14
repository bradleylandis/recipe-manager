// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let numberOfInstructions = 2;

function AddInstruction(){
    const index = numberOfInstructions;
    numberOfInstructions++;

    var labelElement = document.createElement('label');
    labelElement.setAttribute("for", `Instructions_${index}__Description`);
    labelElement.innerText = 'Description';

    var inputElement = document.createElement('input');
    inputElement.setAttribute("type", "text");
    inputElement.setAttribute("id", `Instructions_${index}__Description`);
    inputElement.setAttribute("name", `Instructions[${index}].Description`);
    inputElement.setAttribute("class", "form-control");
    
    var spanElement = document.createElement('span');
    spanElement.setAttribute("class", "field-validation-valid");
    spanElement.setAttribute("data-valmsg-for", `Instructions[${index}].Description`);
    spanElement.setAttribute("data-valmsg-replace", "true");

    var formGroupElement = document.createElement('div');
    formGroupElement.setAttribute("class", "form-group row");
    formGroupElement.appendChild(labelElement);
    formGroupElement.appendChild(inputElement);

    var instructions = document.getElementById('instructions');
    instructions.appendChild(formGroupElement);
}

function AddIngredient(){
    alert('add ingredient');
}
