class CreateProfiles < ActiveRecord::Migration
  def change
    create_table :profiles do |t|
      t.string :avatar
      t.integer :user_id

      t.timestamps
    end
  end
end
