//Bug 1: Loop Output Issue\

//issue: <= causes array index out of bounds

//ANSWER:
for (let i = 0; i < customers.length; i++) {
  console.log(customers[i].name);
}

//Bug 2: filter() Not Working

//issue:Arrow function does not return condition.

//ANSWER:
const activeCustomers = customers.filter((c) => c.active === true);

//Bug 3: Premium Increase Logic Broken

//issue:map() does not return object and mutates original array

//ANSWER:
const updatedPremiums = customers.map((c) => {
  if (c.age >= 50) {
    return { ...c, premium: c.premium * 1.1 };
  }
  return c;});

//Bug 4: Wrong Total Premium Calculation

//issue:reduce() callback does not return accumulated value

//ANSWER:
const totalPremium = customers.reduce((total, c) => {
  return total + c.premium;
}, 0);

//Bug 5: Template Literal Not Printing

//issue: Missing $ in template literal

//ANSWER:
console.log(`Customer ${customers[0].name} has policy ${customers[0].policy}`);

//Bug 6: Policy Count Incorrect

//issue:Dynamic object key not used. count.policy is incorrect.

//ANSWER:
const policyCount = customers.reduce((count, c) => {
  count[c.policy] = (count[c.policy] || 0) + 1;
  return count;}, {});

  //Bug 7: Risk Level Always Undefined

  //issue:Condition chaining incorrect ,second if overrides first.

  //ANSWER:
  const customersWithRisk = customers.map((c) => {
  let riskLevel;
  if (c.age < 35) riskLevel = "Low";
  else if (c.age <= 50) riskLevel = "Medium";
  else riskLevel = "High";
  
  return { ...c, riskLevel };
});

//Bug 8: Active vs Inactive Count Wrong

//issue: loops over index, not object.

//ANSWER:
let active = 0, inactive = 0;

for (const c of customers) {
  if (c.active) active++;
  else inactive++;
}

//Bug 9: Arrow Function Syntax Error

//issue:Missing return due to multiline arrow function.

//ANSWER:
const getLifeCustomers = () =>
  customers
    .filter((c) => c.policy === "Life")
    .map((c) => c.name);

//Bug 10: Sorting Mutates Original Array

//issue:sort() mutates original array.

//ANSWER:
const sortedCustomers = [...customers].sort((a, b) => b.premium - a.premium);
