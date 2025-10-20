// src/app/products/page.tsx
'use client';

import { useEffect, useState } from 'react';
import { Person } from './Models/PersonModel';

export default function PersonsPage() {
  const [persons, setPersons] = useState<Person[]>([]);

  useEffect(() => {
    fetch('http://localhost:5201/api/person/123') // .NET API
      .then((res) => res.json())
      .then((data) => setPersons(data));
  }, []);

  return (
    <main className="p-8">
      <h1 className="text-2xl font-bold mb-4">Persons</h1>
      <ul>
        {persons.map((p) => (
          <li key={p.businessEntityId} className="border-b py-2">
            {p.firstName} - {p.lastName}
          </li>
        ))}
      </ul>
    </main>
  );
}