//Task 1– Select by ID
// Change the dashboard title text to “Customer Insurance Overview”
let title=document.getElementById("pageTitle").innerText="Customer Insurance Overview";

//Task 2– Select by Tag Name
// Select all <li> elements and
// Add border to each <li>
let li=document.getElementsByTagName("li");
for(let i=0;i<li.length;i++){
    li[i].style.border="2px solid black";
    li[i].style.padding="10px";
    li[i].style.width="200px";
    li[i].style.margin="10px";
}

// Log total number of customers
console.log("Total number of customers:", li.length);

//Task 3– Select by Class Name
// Select all .policy elements and:
const policies = document.getElementsByClassName("policy");

for (let i = 0; i < policies.length; i++) {
  policies[i].classList.add("highlight"); // Add highlight class
  policies[i].style.color = "blue";       // Change text color
}

//Task 4 – Select using CSS Selectors
// Select first customer
const firstCustomer = document.querySelector(".customer");
firstCustomer.style.backgroundColor = "lightgray";

//select all cusomers
const allCustomers = document.querySelectorAll(".customer");
console.log("All Customers:", allCustomers.length);

// Mark last customer as active
const lastCustomer=allCustomers[allCustomers.length - 1];
lastCustomer.classList.add("active");

//Task 5 – HTML Object Collections
// Count number of forms
console.log("Number of forms:", document.forms.length);

// Get number of images
console.log("Number of images:", document.images.length);

// Change text of all links to "More Info"
const links = document.links;
for (let i = 0; i < links.length; i++) {
  links[i].innerText = "More Info";
}

//Task 6 – Add New Customer Dynamically

let customerList=document.getElementById("customerList");

let newCustomer=document.createElement("li");
newCustomer.classList.add("customer");
newCustomer.innerText="Bharath-Travel";
customerList.appendChild(newCustomer);

//Task 7 – Attribute-Based Selection
//  Select input fields with type="text"
const textInputs = document.querySelectorAll('input[type="text"]');

textInputs.forEach(function(input) {
  input.style.backgroundColor = "yellow";
  input.placeholder = "Enter Full Name";
});

//Task 8 – Multiple Class Selection
// Select elements with both customer and active classes
const priorityCustomers = document.querySelectorAll(".customer.active");

priorityCustomers.forEach(function(customer) {
  customer.style.color = "darkgreen";
  customer.innerText += " (Priority Customer)";
});


//Task 9 – Descendant vs Child Selector
// Descendant selector
const descendantLis = document.querySelectorAll("#customerList li");

// Child selector
const childLis = document.querySelectorAll("#customerList > li");

console.log("Descendant <li> count:", descendantLis.length);
console.log("Child <li> count:", childLis.length);

// Task 10: Even / Odd customers using :nth-child()

// Select even customers
const evenCustomers = document.querySelectorAll("#customerList li:nth-child(even)");
evenCustomers.forEach(function(li) {
  li.style.backgroundColor = "#e5e7eb"; // light gray
});

// Select odd customers
const oddCustomers = document.querySelectorAll("#customerList li:nth-child(odd)");
oddCustomers.forEach(function(li) {
  li.style.backgroundColor = "#dbeafe"; // light blue
});

// Task 11: Form Elements Collection

// Access form using HTML Form Object Model
const form = document.forms["enquiryForm"];

// Log all input field names
for (let i = 0; i < form.elements.length; i++) {
  console.log("Field Name:", form.elements[i].name);
}

// Disable the submit button
form.elements[form.elements.length - 1].disabled = true;


// Task 12: NodeList vs HTMLCollection

// HTMLCollection (live)
const policyHTMLCollection = document.getElementsByClassName("policy");

// NodeList (static)
const policyNodeList = document.querySelectorAll(".policy");

console.log("HTMLCollection length before:", policyHTMLCollection.length);
console.log("NodeList length before:", policyNodeList.length);

// Dynamically add a new policy
const newPolicy = document.createElement("p");
newPolicy.classList.add("policy");
newPolicy.innerText = "Travel Insurance";
document.body.appendChild(newPolicy);

// Observe after adding
console.log("HTMLCollection length after:", policyHTMLCollection.length);
console.log("NodeList length after:", policyNodeList.length);


// Task 13: Filter customers by textContent

const customers = document.querySelectorAll(".customer");

customers.forEach(function(customer) {
  const text = customer.textContent;

  // Highlight Life policy customers
  if (text.includes("Life")) {
    customer.style.backgroundColor = "lightgreen";
  }

  // Hide Vehicle policy customers
  if (text.includes("Vehicle")) {
    customer.style.display = "none";
  }
});

// Task 14: Closest & Parent Traversal

const customerItems = document.querySelectorAll(".customer");

customerItems.forEach(function(item) {
  item.addEventListener("click", function() {
    const nearestUL = item.closest("ul"); // find nearest parent <ul>
    nearestUL.style.border = "3px solid purple";
    nearestUL.style.padding = "10px";
  });
});

// Task 15: Select all policy <p> except first one

const policiesExceptFirst = document.querySelectorAll(
  "p.policy:not(:first-child)"
);

policiesExceptFirst.forEach(function(policy) {
  policy.style.fontStyle = "italic";
  policy.innerText = "✔ " + policy.innerText;
});

