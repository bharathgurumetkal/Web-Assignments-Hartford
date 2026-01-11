let form=document.getElementById('insuranceForm');

form.addEventListener('submit',function(event){
    event.preventDefault();

    document.querySelectorAll('.error').forEach(e => e.innerText = "");
document.getElementById('successMessage').innerText = "";

    let name=document.getElementById('name').value.trim();
    let email=document.getElementById('email').value.trim();
    let mobile=document.getElementById('mobile').value.trim();
    let requestType=document.getElementById('requestType').value;
    let policyType=document.getElementById('policyType').value;
    let message=document.getElementById('message').value.trim();
    let rating = document.querySelector('input[name="rating"]:checked');
;

    let isValid=true;

    if(name === ""){
        document.getElementById('nameError').innerText="Name is required";
        isValid=false;
    }

    if(!/^\d{10}$/.test(mobile)){
        document.getElementById('mobileError').innerText="Enter a valid 10-digit mobile number";
        isValid=false;
    }

    if(email===""){
        document.getElementById('emailError').innerText="Email is required";
        isValid=false;
    }

 if(requestType === ""){
        document.getElementById('requestError').innerText="Please select a request type";
        isValid=false;
    }

    if(policyType === ""){
        document.getElementById('policyError').innerText="Please select a policy type";
        isValid=false;
    }

    if(message.length<10){
        document.getElementById('messageError').innerText="Message must be at least 10 characters long";
        isValid=false;
    }

if(!rating){
   document.getElementById('ratingError').innerText="Please provide a rating";
   isValid=false;
}

    if(isValid){
        document.getElementById('successMessage').innerText="Thank you! Your enquiry has been successfully submitted.";
        form.reset();
    }

});