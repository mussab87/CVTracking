
/* ---------------------------------------------
     Images Drag & Drop
--------------------------------------------- */

//selecting all required elements

var dropArea = document.querySelector(".drag-area") !== null ? document.querySelector(".drag-area") : null,
    dragText = dropArea !== null ? dropArea.querySelector("header") : null,
    button = dropArea !== null ? dropArea.querySelector("button") : null,
    input = document.getElementById("fileload");
//inputpersonalphoto = document.getElementById("personalphoto"); //dropArea.querySelector("input");
let file; //this is a global variable and we'll use it inside multiple functions

//button.onclick = () => {
//    if (input != null) {
//        input.click();
//    }
//    //if (inputpersonalphoto != null) {
//    //    inputpersonalphoto.click();
//    //}
//    //if user click on the button then the input also clicked
//}

var foreign = document.getElementById("fileload");
function foreignlogo() {
    dropArea = document.querySelector(".drag-area");
    foreign.click();
}

var local = document.getElementById("fileload");
function Locallogo() {
    dropArea = document.querySelector(".drag-area");
    local.click();
}

var inputpersonalphoto = document.getElementById("personalphoto");
function personalphoto() {
    dropArea = document.querySelector(".drag-area");
    inputpersonalphoto.click();
}

var posterphoto = document.getElementById("posterphoto");
function posterphotoclick() {
    dropArea = document.querySelectorAll(".drag-area")[1];
    posterphoto.click();
}

var passportphoto = document.getElementById("passportphoto");
function passportphotoclick() {
    dropArea = document.querySelectorAll(".drag-area")[2];
    passportphoto.click();
}

if (foreign != null) {
    input.addEventListener("change", function () {
        $('#imageInput').val($(this).val());
        //getting user select file and [0] this means if user select multiple files then we'll select only the first one
        file = this.files[0];
        dropArea.classList.add("active");
        showFile(); //calling function
    });
}

if (inputpersonalphoto != null) {
    inputpersonalphoto.addEventListener("change", function () {
        $('#imageInput').val($(this).val());
        //getting user select file and [0] this means if user select multiple files then we'll select only the first one
        file = this.files[0];
        dropArea.classList.add("active");
        showFile(); //calling function
    });
}

if (posterphoto != null) {
    posterphoto.addEventListener("change", function () {
        $('#imageInput').val($(this).val());
        //getting user select file and [0] this means if user select multiple files then we'll select only the first one
        file = this.files[0];
        dropArea.classList.add("active");
        showFile(true); //calling function
    });
}

if (passportphoto != null) {
    passportphoto.addEventListener("change", function () {
        $('#imageInput').val($(this).val());
        //getting user select file and [0] this means if user select multiple files then we'll select only the first one
        file = this.files[0];
        dropArea.classList.add("active");
        showFile(false, true); //calling function
    });
}




//If user Drag File Over DropArea
if (dropArea != null) {
    dropArea.addEventListener("dragover", (event) => {
        event.preventDefault(); //preventing from default behaviour
        dropArea.classList.add("active");
        dragText.textContent = "Release to Upload File";
    });

    //If user leave dragged File from DropArea
    dropArea.addEventListener("dragleave", () => {
        dropArea.classList.remove("active");
        dragText.textContent = "Drag & Drop to Upload File";
    });

    //If user drop File on DropArea
    dropArea.addEventListener("drop", (event) => {
        event.preventDefault(); //preventing from default behaviour
        //getting user select file and [0] this means if user select multiple files then we'll select only the first one
        file = event.dataTransfer.files[0];
        showFile(); //calling function
    });
}




function showFile(poster, passport) {
    let fileType = file.type; //getting selected file type
    let validExtensions = ["image/jpeg", "image/jpg", "image/png"]; //adding some valid image extensions in array
    if (validExtensions.includes(fileType)) { //if user selected file is an image file
        let fileReader = new FileReader(); //creating new FileReader object
        fileReader.onload = () => {
            let fileURL = fileReader.result; //passing user file source in fileURL variable
            // UNCOMMENT THIS BELOW LINE. I GOT AN ERROR WHILE UPLOADING THIS POST SO I COMMENTED IT
            let imgTag = `<img src="${fileURL}" alt="image">`; //creating an img tag and passing user selected file source inside src attribute
            dropArea.innerHTML = imgTag; //adding that created img tag inside dropArea container

            if (poster) {
                document.getElementById("posterimg").src = fileURL;
            }
            if (passport) {
                document.getElementById("passportimg").src = fileURL;
            }

        }

        //alert(document.getElementById("imgsource").value);
        fileReader.readAsDataURL(file);


    } else {
        alert("This is not an Image File!");
        dropArea.classList.remove("active");
        dragText.textContent = "Drag & Drop to Upload File";
    }
}





//const dropArea2 = document.querySelector("#dragArea2"),
//dragText2 = dropArea2.querySelector("header"),
//button2 = dropArea2.querySelector("button"),
//input2 = dropArea2.querySelector("input");
//let file2; //this is a global variable and we'll use it inside multiple functions

//button2.onclick = () => {
//    input2.click(); //if user click on the button then the input also clicked
//}

//input2.addEventListener("change", function () {
//    $('#imageInput2').val($(this).val());
//    //getting user select file and [0] this means if user select multiple files then we'll select only the first one
//    file2 = this.files[0];
//    dropArea2.classList.add("active");
//    showFile2(); //calling function
//});


//If user Drag File Over DropArea
//dropArea2.addEventListener("dragover", (event) => {
//    event.preventDefault(); //preventing from default behaviour
//    dropArea2.classList.add("active");
//    dragText2.textContent = "Release to Upload File";
//});

//If user leave dragged File from DropArea
//dropArea2.addEventListener("dragleave", () => {
//    dropArea2.classList.remove("active");
//    dragText2.textContent = "Drag & Drop to Upload File";
//});

//If user drop File on dropArea2
//dropArea2.addEventListener("drop", (event) => {
//    event.preventDefault(); //preventing from default behaviour
//    //getting user select file and [0] this means if user select multiple files then we'll select only the first one
//    file = event.dataTransfer.files[0];
//    showFile2(); //calling function
//});

function showFile2() {
    let fileType2 = file2.type; //getting selected file type
    let validExtensions2 = ["image/jpeg", "image/jpg", "image/png"]; //adding some valid image extensions in array
    if (validExtensions2.includes(fileType2)) { //if user selected file is an image file
        let fileReader2 = new FileReader(); //creating new FileReader2 object
        fileReader2.onload = () => {
            let fileURL = fileReader2.result; //passing user file source in fileURL variable
            // UNCOMMENT THIS BELOW LINE. I GOT AN ERROR WHILE UPLOADING THIS POST SO I COMMENTED IT
            let imgTag2 = `<img src="${fileURL}" alt="image">`; //creating an img tag and passing user selected file source inside src attribute
            dropArea2.innerHTML = imgTag2; //adding that created img tag inside dropArea container
        }
        fileReader2.readAsDataURL(file2);
    } else {
        alert("This is not an Image File!");
        dropArea2.classList.remove("active");
        dragText2.textContent = "Drag & Drop to Upload File";
    }
}