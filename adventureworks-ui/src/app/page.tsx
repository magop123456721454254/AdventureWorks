'use client';
import { useQuery } from '@apollo/client';
import { GET_PERSONS } from './functions/queries/personQueries';
import { Person } from '@/app/models/personModel';

export default function PersonsPage() {
  const { data, loading, error, fetchMore } = useQuery(GET_PERSONS, {
    variables: { first: 5, after: null },
  });

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  return (
    <html>
      <body>
        <ul>
          {data.personsEndpoint.nodes.map((person: Person) => (
            <li key={person.businessEntityId}>
              {person.firstName} {person.lastName}
            </li>
          ))}
        </ul>
      </body>
    </html>
  );
}
