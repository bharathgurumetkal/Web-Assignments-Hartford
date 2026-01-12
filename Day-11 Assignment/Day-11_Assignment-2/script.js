//Exercise 1 – Basic (Event Bubbling) 
//You are building an insurance payment page. A button "Pay Premium" is inside a div "paymentSection". 
//Tasks: 
//1. Add click event to both div and button. 
//2. Observe and write the output order when button is clicked. 
//3. Mention which event phase is occurring.

let div=document.getElementById("paymentSection")
let btn=document.getElementById("payBtn")

div.addEventListener("click",function(){
    console.log("Payment Section(Div) Clicked")
})

btn.addEventListener("click",function(){
    console.log("Payment Button Clicked")
})
//When the button is clicked, the output order is:
//Payment Button Clicked
//Payment Section(Div) Clicked
//This occurs during the bubbling phase of event propagation.

//Exercise 2 – Basic (Event Capturing) 
//On a policy page, a container validates user before showing policy details. 
//Tasks: 
//1. Use capturing phase for both parent and child. 
//2. Ensure parent runs first. 
//3. Write expected console output.
const container = document.getElementById("paymentSection");
const button = document.getElementById("payBtn");

// Capturing phase = true as third parameter
container.addEventListener("click", function() {
  console.log("Parent Capturing");
}, true);

button.addEventListener("click", function() {
  console.log("Child Capturing");
}, true);

//output when button clicked is:

//Parent Capturing
//Child Capturing
//This occurs during the capturing phase of event propagation.(Event travels from parent → child first.)

/*Exercise 3 – Intermediate (stopPropagation)
Insurance dashboard shows policy cards. Clicking card navigates to details, but clicking delete should 
only delete. 
Tasks: 
1. Stop event bubbling on delete button. 
2. Prevent navigation log from appearing. 
3. Write JavaScript code*/
let card=document.getElementById("policyCard")
let deleteBtn=document.getElementById("deleteBtn")

card.addEventListener("click",function(){
    console.log("Navigating to policy details...")
})

deleteBtn.addEventListener("click",function(event){
    event.stopPropagation();   
    console.log("Policy deleted.")
});
//Output when delete button is clicked:
//policy deleted.
//The navigation log does not appear because event propagation is stopped at the delete button.


/*Exercise 4 – Intermediate (Reinforce bubbling, capturing, and stopPropagaƟ on together)
You are building an Insurance Claims Dashboard.
 Each Claim Row is clickable → Opens Claim Details page
 Inside each row there is an Approve Claim buƩ on → Approves the claim without navigaƟ on
This is extremely common in insurance admin panels.
Tasks 
1. Add click event on claimRow
 Log: Opening Claim Details
2. Add click event on Approve Claim buƩ on
 Log: Claim Approved
3. Ensure that clicking Approve Claim
 does NOT open claim details
4. Explain:
 What happens without stopPropagation()
 What happens with stopPropagation()*/

let claimRow=document.getElementById("claimRow")
let approveBtn=document.getElementById("approveBtn")

claimRow.addEventListener("click",function(){
    console.log("Opening Claim Details")
});

approveBtn.addEventListener("click",function(event){
    event.stopPropagation();
    console.log("Claim Approved")
});

//output when approve button is clicked without stopPropagation():
//Claim Approved
//Opening Claim Details
//Both logs appear because the click event bubbles up to the claim row, triggering its event listener.

//output when approve button is clicked with stopPropagation():
//Claim Approved
//The claim details do not open because event propagation is stopped at the approve button. 

