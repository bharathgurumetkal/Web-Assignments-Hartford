
const plans = [
  {name:"Health Insurance", base:3000, coverage:"5L"},
  {name:"Life Insurance", base:5000, coverage:"10L"},
  {name:"Vehicle Insurance", base:2000, coverage:"3L"}
];

let customers = JSON.parse(localStorage.getItem("customers")) || [];


const plansContainer = document.getElementById("plansContainer");
if(plansContainer){
  plans.map(plan=>{
    plansContainer.innerHTML += `
      <div class="bg-white p-5 rounded shadow text-center">
        <h3 class="font-bold">${plan.name}</h3>
        <p>Base Premium: ₹${plan.base}</p>
        <p>Coverage: ${plan.coverage}</p>
        <button class="btn-blue mt-3">Enroll</button>
      </div>
    `;
  });
}


function calculatePremium(age, policyType, coverage){
  let base = policyType==="Health" ? 3000 :
             policyType==="Life" ? 5000 : 2000;

  let premium = base;
  if(age > 45) premium *= 1.2;
  premium += (coverage - 1) * 500;

  return Math.round(premium);
}


const form = document.getElementById("customerForm");
if(form){
  const coverageSlider = document.getElementById("coverage");
  const coverageValue = document.getElementById("coverageValue");

  coverageSlider.addEventListener("input",()=>{
    coverageValue.innerText = coverageSlider.value;
  });

  form.addEventListener("submit", function(e){
    e.preventDefault();

    document.querySelectorAll(".error").forEach(el=>el.innerText="");
    document.getElementById("successMsg").innerText="";

    let name = document.getElementById("name").value.trim();
    let age = Number(document.getElementById("age").value);
    let email = document.getElementById("email").value.trim();
    let policyType = document.getElementById("policyType").value;
    let coverage = Number(coverageSlider.value);

    let valid=true;

    if(name===""){document.getElementById("nameError").innerText="Name required"; valid=false;}
    if(!age){document.getElementById("ageError").innerText="Valid age required"; valid=false;}
    if(email===""){document.getElementById("emailError").innerText="Email required"; valid=false;}
    if(policyType===""){document.getElementById("policyError").innerText="Select policy"; valid=false;}

    if(!valid) return;

    let premium = calculatePremium(age, policyType, coverage);

    let customer = {id:Date.now(), name, age, policyType, coverage, premium};
    customers.push(customer);
    localStorage.setItem("customers", JSON.stringify(customers));

    document.getElementById("successMsg").innerText="Enquiry submitted successfully!";
    form.reset();
    coverageValue.innerText="1";
  });
}


const tableBody = document.getElementById("customerTable");
if(tableBody){
  function renderTable(data){
    tableBody.innerHTML="";
    data.map(c=>{
      tableBody.innerHTML += `
        <tr class="text-center border-b">
          <td>${c.name}</td>
          <td>${c.age}</td>
          <td>${c.policyType}</td>
          <td>${c.coverage}</td>
          <td>₹${c.premium}</td>
        </tr>
      `;
    });
  }

  function applyFilters(){
    let policy = document.getElementById("filterPolicy").value;
    let search = document.getElementById("searchName").value.toLowerCase();

    let filtered = customers.filter(c =>
      (policy==="All" || c.policyType===policy) &&
      c.name.toLowerCase().includes(search)
    );

    renderTable(filtered);
  }

  document.getElementById("filterPolicy").addEventListener("change",applyFilters);
  document.getElementById("searchName").addEventListener("input",applyFilters);

  renderTable(customers);
}


const totalCustomers = document.getElementById("totalCustomers");
const totalPremium = document.getElementById("totalPremium");

if(totalCustomers && totalPremium){
  totalCustomers.innerText = customers.length;
  totalPremium.innerText = customers.reduce((sum,c)=>sum+c.premium,0);
}
